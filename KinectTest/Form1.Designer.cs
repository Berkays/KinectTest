namespace KinectTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lbl_Frame;
            System.Windows.Forms.Label lbl_FocusTitle;
            System.Windows.Forms.Label lbl_PointCaption;
            System.Windows.Forms.Label lbl_DistanceCaption;
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Depth = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.num_elevation = new System.Windows.Forms.NumericUpDown();
            this.lbl_elevation = new System.Windows.Forms.Label();
            this.btn_elevation = new System.Windows.Forms.Button();
            this.btn_Color = new System.Windows.Forms.Button();
            this.chk_InvertColor = new System.Windows.Forms.CheckBox();
            this.focusMarker = new System.Windows.Forms.PictureBox();
            this.lbl_frameCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Point = new System.Windows.Forms.Label();
            this.lbl_Distance = new System.Windows.Forms.Label();
            lbl_Frame = new System.Windows.Forms.Label();
            lbl_FocusTitle = new System.Windows.Forms.Label();
            lbl_PointCaption = new System.Windows.Forms.Label();
            lbl_DistanceCaption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_elevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusMarker)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(13, 13);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(144, 40);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start Camera";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.connectSensor);
            // 
            // btn_Depth
            // 
            this.btn_Depth.Location = new System.Drawing.Point(163, 13);
            this.btn_Depth.Name = "btn_Depth";
            this.btn_Depth.Size = new System.Drawing.Size(144, 40);
            this.btn_Depth.TabIndex = 1;
            this.btn_Depth.Text = "Get Depth";
            this.btn_Depth.UseVisualStyleBackColor = true;
            this.btn_Depth.Click += new System.EventHandler(this.getDepthData);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(12, 244);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(57, 17);
            this.lbl_status.TabIndex = 2;
            this.lbl_status.Text = "DATA : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Stop Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.disconnectSensor);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(163, 59);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 480);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // num_elevation
            // 
            this.num_elevation.Enabled = false;
            this.num_elevation.Location = new System.Drawing.Point(13, 132);
            this.num_elevation.Maximum = new decimal(new int[] {
            27,
            0,
            0,
            0});
            this.num_elevation.Minimum = new decimal(new int[] {
            27,
            0,
            0,
            -2147483648});
            this.num_elevation.Name = "num_elevation";
            this.num_elevation.Size = new System.Drawing.Size(143, 22);
            this.num_elevation.TabIndex = 8;
            this.num_elevation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_elevation
            // 
            this.lbl_elevation.AutoSize = true;
            this.lbl_elevation.Location = new System.Drawing.Point(12, 111);
            this.lbl_elevation.Name = "lbl_elevation";
            this.lbl_elevation.Size = new System.Drawing.Size(117, 17);
            this.lbl_elevation.TabIndex = 7;
            this.lbl_elevation.Text = "Elevation Degree";
            // 
            // btn_elevation
            // 
            this.btn_elevation.Location = new System.Drawing.Point(15, 160);
            this.btn_elevation.Name = "btn_elevation";
            this.btn_elevation.Size = new System.Drawing.Size(142, 42);
            this.btn_elevation.TabIndex = 9;
            this.btn_elevation.Text = "Change Elevation";
            this.btn_elevation.UseVisualStyleBackColor = true;
            this.btn_elevation.Click += new System.EventHandler(this.btn_elevation_Click);
            // 
            // btn_Color
            // 
            this.btn_Color.Location = new System.Drawing.Point(313, 13);
            this.btn_Color.Name = "btn_Color";
            this.btn_Color.Size = new System.Drawing.Size(144, 40);
            this.btn_Color.TabIndex = 10;
            this.btn_Color.Text = "Get Color";
            this.btn_Color.UseVisualStyleBackColor = true;
            this.btn_Color.Click += new System.EventHandler(this.getColorData);
            // 
            // chk_InvertColor
            // 
            this.chk_InvertColor.AutoSize = true;
            this.chk_InvertColor.Location = new System.Drawing.Point(15, 208);
            this.chk_InvertColor.Name = "chk_InvertColor";
            this.chk_InvertColor.Size = new System.Drawing.Size(109, 21);
            this.chk_InvertColor.TabIndex = 11;
            this.chk_InvertColor.Text = "Invert Colors";
            this.chk_InvertColor.UseVisualStyleBackColor = true;
            this.chk_InvertColor.CheckedChanged += new System.EventHandler(this.chk_InvertColor_CheckedChanged);
            // 
            // focusMarker
            // 
            this.focusMarker.BackColor = System.Drawing.Color.Red;
            this.focusMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.focusMarker.Location = new System.Drawing.Point(146, 219);
            this.focusMarker.Name = "focusMarker";
            this.focusMarker.Size = new System.Drawing.Size(10, 10);
            this.focusMarker.TabIndex = 12;
            this.focusMarker.TabStop = false;
            // 
            // lbl_Frame
            // 
            lbl_Frame.AutoSize = true;
            lbl_Frame.Location = new System.Drawing.Point(12, 519);
            lbl_Frame.Name = "lbl_Frame";
            lbl_Frame.Size = new System.Drawing.Size(56, 17);
            lbl_Frame.TabIndex = 13;
            lbl_Frame.Text = "Frame :";
            // 
            // lbl_frameCount
            // 
            this.lbl_frameCount.AutoSize = true;
            this.lbl_frameCount.Location = new System.Drawing.Point(68, 519);
            this.lbl_frameCount.Name = "lbl_frameCount";
            this.lbl_frameCount.Size = new System.Drawing.Size(16, 17);
            this.lbl_frameCount.TabIndex = 14;
            this.lbl_frameCount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lbl_Distance);
            this.panel1.Controls.Add(lbl_DistanceCaption);
            this.panel1.Controls.Add(this.lbl_Point);
            this.panel1.Controls.Add(lbl_PointCaption);
            this.panel1.Controls.Add(lbl_FocusTitle);
            this.panel1.Location = new System.Drawing.Point(13, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 89);
            this.panel1.TabIndex = 15;
            // 
            // lbl_FocusTitle
            // 
            lbl_FocusTitle.AutoSize = true;
            lbl_FocusTitle.Location = new System.Drawing.Point(48, 10);
            lbl_FocusTitle.Name = "lbl_FocusTitle";
            lbl_FocusTitle.Size = new System.Drawing.Size(46, 17);
            lbl_FocusTitle.TabIndex = 0;
            lbl_FocusTitle.Text = "Focus";
            lbl_FocusTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_PointCaption
            // 
            lbl_PointCaption.AutoSize = true;
            lbl_PointCaption.Location = new System.Drawing.Point(9, 37);
            lbl_PointCaption.Name = "lbl_PointCaption";
            lbl_PointCaption.Size = new System.Drawing.Size(48, 17);
            lbl_PointCaption.TabIndex = 1;
            lbl_PointCaption.Text = "Point :";
            lbl_PointCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Point
            // 
            this.lbl_Point.AutoSize = true;
            this.lbl_Point.Location = new System.Drawing.Point(63, 37);
            this.lbl_Point.Name = "lbl_Point";
            this.lbl_Point.Size = new System.Drawing.Size(38, 17);
            this.lbl_Point.TabIndex = 2;
            this.lbl_Point.Text = "(0,0)";
            this.lbl_Point.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Distance
            // 
            this.lbl_Distance.AutoSize = true;
            this.lbl_Distance.Location = new System.Drawing.Point(78, 63);
            this.lbl_Distance.Name = "lbl_Distance";
            this.lbl_Distance.Size = new System.Drawing.Size(31, 17);
            this.lbl_Distance.TabIndex = 4;
            this.lbl_Distance.Text = "5 m";
            this.lbl_Distance.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_DistanceCaption
            // 
            lbl_DistanceCaption.AutoSize = true;
            lbl_DistanceCaption.Location = new System.Drawing.Point(9, 63);
            lbl_DistanceCaption.Name = "lbl_DistanceCaption";
            lbl_DistanceCaption.Size = new System.Drawing.Size(71, 17);
            lbl_DistanceCaption.TabIndex = 3;
            lbl_DistanceCaption.Text = "Distance :";
            lbl_DistanceCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_frameCount);
            this.Controls.Add(lbl_Frame);
            this.Controls.Add(this.focusMarker);
            this.Controls.Add(this.chk_InvertColor);
            this.Controls.Add(this.btn_Color);
            this.Controls.Add(this.btn_elevation);
            this.Controls.Add(this.num_elevation);
            this.Controls.Add(this.lbl_elevation);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_Depth);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form1";
            this.Text = "Kinect Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_elevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusMarker)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Depth;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown num_elevation;
        private System.Windows.Forms.Label lbl_elevation;
        private System.Windows.Forms.Button btn_elevation;
        private System.Windows.Forms.Button btn_Color;
        private System.Windows.Forms.CheckBox chk_InvertColor;
        private System.Windows.Forms.PictureBox focusMarker;
        private System.Windows.Forms.Label lbl_frameCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Point;
        private System.Windows.Forms.Label lbl_Distance;
    }
}

