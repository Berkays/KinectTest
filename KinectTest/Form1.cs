using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace KinectTest
{
    public partial class Form1 : Form
    {
        KinectSensor sensor;
        Bitmap bmp;
        Graphics contentGraphics;
        DepthImagePixel[] prevData;

        Thread t = new Thread(delegate () { });
        bool isWorking = false;

        int currentFrame = 0;
        int CurrentFrame
        {
            get
            {
                return currentFrame;
            }

            set
            {
                currentFrame = value;
                lbl_frameCount.Text = currentFrame.ToString();
            }
        }

        const float RGB_RATIO = 0.06375f;
        bool InvertColor = false;

        Point focusPoint = new Point() { X = -1 };
        bool focusSet = false;
        bool isSet = false;


        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //pictureBox.Image = bmp;
            contentGraphics = pictureBox.CreateGraphics();

        }


        private void connectSensor(object sender, EventArgs e)
        {
            if (KinectSensor.KinectSensors.Count > 0)
            {
                sensor = KinectSensor.KinectSensors[0];

                sensor.Start();

                //Misc
                num_elevation.Enabled = true;
                num_elevation.Value = sensor.ElevationAngle;

                lbl_status.Text = sensor.Status.ToString();

                Debug.WriteLine("\n\n Program Started \n\n");
            }
            else
            {
                lbl_status.Text = "No Sensor Found";
            }
        }
        private void disconnectSensor(object sender, EventArgs e)
        {
            if (sensor != null)
            {

                sensor.ColorFrameReady -= Sensor_ColorFrameReady;
                sensor.DepthFrameReady -= Sensor_DepthFrameReady;
                sensor.Stop();

                contentGraphics.DrawImage(new Bitmap(640, 480, PixelFormat.Format32bppRgb), 0, 0);
                lbl_status.Text = sensor.Status.ToString();
            }
        }
        private void setElevation(int degree)
        {
            if (Math.Abs(degree) > 27)
                return;

            try
            {
                if (sensor != null)
                    sensor.Start();
            }
            catch (System.IO.IOException)
            { }

            sensor.ElevationAngle = degree;
        }

        void getDepthData(object sender, EventArgs e)
        {
            if (sensor == null)
                return;

            sensor.ColorStream.Disable();
            sensor.ColorFrameReady -= Sensor_ColorFrameReady;

            sensor.DepthFrameReady += Sensor_DepthFrameReady;
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

            //sensor.Start();
        }
        void getColorData(object sender, EventArgs e)
        {
            if (sensor == null)
                return;

            sensor.DepthStream.Disable();
            sensor.DepthFrameReady -= Sensor_DepthFrameReady;

            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.ColorFrameReady += Sensor_ColorFrameReady;

            //sensor.Start();
        }

        private void Sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            DepthImageFrame frame = e.OpenDepthImageFrame();


            if (frame != null)
            {
                CurrentFrame++;

                DepthImagePixel[] pixelArray = new DepthImagePixel[sensor.DepthStream.FramePixelDataLength];

                //Copy depth data to Array
                frame.CopyDepthImagePixelDataTo(pixelArray);


                if (isSet == false && focusPoint.X != -1)
                {
                    focusPoint.Depth = pixelArray[pointToIndex(frame.Width, focusPoint)].Depth;
                    lbl_Point.Text = "(" + focusPoint.X + "," + focusPoint.Y + ")";
                    lbl_Distance.Text = (float)focusPoint.Depth / 1000 + " m";

                    //Debug.WriteLine("Set New Focus Point On {" + focusPoint.X + "," + focusPoint.Y + "} Distance : " + (float)focusPoint.Depth / 1000 + " Meters");
                    isSet = true;
                    focusSet = true;
                }
                else if (focusSet == true)
                {
                    lbl_Distance.Text = (float)focusPoint.Depth / 1000 + " m";
                }

                //Dont collide with graphics driver
                if (isWorking == false)
                {
                    isWorking = true;

                    t = new Thread(() =>
                    {
                        depthSet(ref pixelArray, frame.Width, frame.Height);
                    });

                    t.Start();

                    //Modify Text
                    lbl_status.Text = "Depth Average : " + average(ref pixelArray);
                }

                frame.Dispose();
            }
            else
            {
                //If frame is null do nothing...

                //Modify Text
                lbl_status.Text = "DATA : Not Received";
            }

        }
        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            ColorImageFrame frame = e.OpenColorImageFrame();

            if (frame != null)
            {
                CurrentFrame++;

                byte[] pixelData = new byte[frame.PixelDataLength];

                frame.CopyPixelDataTo(pixelData);

                if (isWorking == false)
                {
                    isWorking = true;

                    t = new Thread(() =>
                    {
                        colorSet(pixelData);
                    });
                    t.Start();
                }

                //Modify Text
                lbl_status.Text = "Data : Color Data Received";

                frame.Dispose();

            }
            else
            {
                //If frame is null do nothing...

                //Modify Text
                lbl_status.Text = "Data : No Data Received";
            }
        }

        private void depthSet(ref DepthImagePixel[] data, int Width, int Height)
        {
            if (prevData == null)
                prevData = data;

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int counter = 0, rgb = 0; counter < rgbValues.Length / 4; counter++, rgb += 4)
            {
                int clrComponent = (int)(data[counter].Depth * RGB_RATIO);

                //if ((prevData[counter].Depth == 0 && data[counter].Depth != 0) || (prevData[counter].Depth != 0 && data[counter].Depth == 0))
                //{
                //    rgbValues[rgb] = 0;
                //    rgbValues[rgb + 1] = 0;
                //    rgbValues[rgb + 2] = 0;
                //    continue;
                //}

                if (data[counter].Depth == 0)
                {
                    //Look for non zero pixel

                    int newIndex = findClearPoint(ref data, counter, Width, Height, 5);

                    clrComponent = (int)(data[newIndex].Depth * RGB_RATIO);

                    rgbValues[rgb] = (byte)clrComponent;
                    rgbValues[rgb + 1] = (byte)clrComponent;
                    rgbValues[rgb + 2] = (byte)clrComponent;

                    continue;
                    //bool flag = false;
                    //for (int iterator = counter; iterator > 0; iterator--)
                    //{
                    //    if (data[iterator].Depth != 0)
                    //    {
                    //        int temp = (int)(data[iterator].Depth * RGB_RATIO);

                    //        rgbValues[rgb] = (byte)temp;
                    //        rgbValues[rgb + 1] = (byte)temp;
                    //        rgbValues[rgb + 2] = (byte)temp;

                    //        flag = true;
                    //        break;

                    //    }
                    //}

                    //if (!flag)
                    //{
                    //    rgbValues[rgb] = 0;
                    //    rgbValues[rgb + 1] = 0;
                    //    rgbValues[rgb + 2] = 0;
                    //}
                    //continue;
                }

                if (InvertColor)
                    clrComponent = 255 - clrComponent;


                rgbValues[rgb] = (byte)clrComponent;
                rgbValues[rgb + 1] = (byte)clrComponent;
                rgbValues[rgb + 2] = (byte)clrComponent;

                //if (data[counter].IsKnownDepth)
                //{
                //    rgbValues[rgb] = (byte)clrComponent;
                //    rgbValues[rgb + 1] = (byte)clrComponent;
                //    rgbValues[rgb + 2] = (byte)clrComponent;
                //}
                //else
                //{
                //    rgbValues[rgb] = 255;
                //    rgbValues[rgb + 1] = 255;
                //    rgbValues[rgb + 2] = 255;
                //}
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            contentGraphics.DrawImage(bmp, 0, 0);

            //Check Depth Change
            if (focusSet)
            {
                int fData = pointToIndex(Width, focusPoint);

                int Difference = Math.Abs(data[fData].Depth - focusPoint.Depth);

                if (Difference > 20)
                {
                    //Debug.WriteLine("Depth Has Changed (New Distance : " + (float)data[fData].Depth / 1000 + " Meters)");
                    focusPoint.Depth = data[fData].Depth;
                }
            }



            isWorking = false;

            prevData = data;
        }
        private void colorSet(byte[] data)
        {

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red. 
            for (int rgb = 0; rgb < data.Length; rgb++)
            {
                byte pixelColor = data[rgb];
                if (InvertColor)
                    pixelColor = (byte)(255 - pixelColor);
                rgbValues[rgb] = pixelColor;
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            contentGraphics.DrawImage(bmp, 0, 0);

            isWorking = false;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Get point of click
            int X = e.X;
            int Y = e.Y;

            focusPoint.X = X;
            focusPoint.Y = Y;

            //Move Marker to the posiiton
            focusMarker.Location = new System.Drawing.Point(pictureBox.Location.X + X, pictureBox.Location.Y + Y);

            isSet = false;
            focusSet = false;
        }
        private void btn_elevation_Click(object sender, EventArgs e)
        {
            setElevation((int)num_elevation.Value);
        }
        private void chk_InvertColor_CheckedChanged(object sender, EventArgs e)
        {
            InvertColor = ((CheckBox)sender).Checked;
        }


        private int average(ref DepthImagePixel[] pixelArray)
        {
            int sum = 0;

            for (int i = 0; i < pixelArray.Length; i += 3)
            {
                sum += pixelArray[i].Depth;
            }

            int average = sum / pixelArray.Length;

            return average;
        }

        private int pointToIndex(int Width, Point point)
        {
            int index = point.X + (Width - 1) * point.Y;

            return index;
        }
        private int pointToIndex(int Width, int x, int y)
        {
            int index = x + (Width - 1) * y;

            return index;
        }
        private Point indexToPoint(int Width, int Height, int index)
        {
            Point p = new Point();

            p.X = index % Width;
            p.Y = (int)(index / Width);

            return p;
        }

        private int findClearPoint(ref DepthImagePixel[] pixelArray, int current, int Width, int Height, int radius)
        {
            Point currentPoint = indexToPoint(Width, Height, current);

            for (int x = currentPoint.X - radius; x < currentPoint.X + radius; x++)
            {
                if (x < 0 || x > Width)
                    continue;

                for (int y = currentPoint.Y - radius; y < currentPoint.Y + radius; y++)
                {
                    if (y < 0 || y > Height)
                        continue;

                    int newIndex = pointToIndex(Width, x, y);

                    if (pixelArray[newIndex].Depth != 0)
                        return newIndex;

                }
            }


            return 0;
        }
        struct Point
        {
            public int X;
            public int Y;
            public int Depth;
        }
    }
}