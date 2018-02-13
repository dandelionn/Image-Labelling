namespace ImageCropper
{
    partial class ContourForm
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
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonSetSaveDir = new System.Windows.Forms.Button();
            this.buttonOpenSaveDir = new System.Windows.Forms.Button();
            this.textBoxSaveDirPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPolygon = new System.Windows.Forms.Button();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonTetragon = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonNothing = new System.Windows.Forms.Button();
            this.flowLayoutPanelContour = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonGenerateContours = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveImage.BackColor = System.Drawing.Color.White;
            this.buttonSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveImage.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonSaveImage.Location = new System.Drawing.Point(1039, 426);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(84, 43);
            this.buttonSaveImage.TabIndex = 1;
            this.buttonSaveImage.Text = "save";
            this.buttonSaveImage.UseVisualStyleBackColor = false;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonSetSaveDir
            // 
            this.buttonSetSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSetSaveDir.BackColor = System.Drawing.Color.White;
            this.buttonSetSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetSaveDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetSaveDir.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonSetSaveDir.Location = new System.Drawing.Point(5, 552);
            this.buttonSetSaveDir.Name = "buttonSetSaveDir";
            this.buttonSetSaveDir.Size = new System.Drawing.Size(120, 25);
            this.buttonSetSaveDir.TabIndex = 4;
            this.buttonSetSaveDir.Text = "set save dir";
            this.buttonSetSaveDir.UseVisualStyleBackColor = false;
            this.buttonSetSaveDir.Click += new System.EventHandler(this.buttonSetSaveDir_Click);
            // 
            // buttonOpenSaveDir
            // 
            this.buttonOpenSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenSaveDir.BackColor = System.Drawing.Color.White;
            this.buttonOpenSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenSaveDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenSaveDir.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonOpenSaveDir.Location = new System.Drawing.Point(1039, 552);
            this.buttonOpenSaveDir.Name = "buttonOpenSaveDir";
            this.buttonOpenSaveDir.Size = new System.Drawing.Size(84, 25);
            this.buttonOpenSaveDir.TabIndex = 5;
            this.buttonOpenSaveDir.Text = "open dir";
            this.buttonOpenSaveDir.UseVisualStyleBackColor = false;
            this.buttonOpenSaveDir.Click += new System.EventHandler(this.buttonOpenSaveDir_Click);
            // 
            // textBoxSaveDirPath
            // 
            this.textBoxSaveDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaveDirPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSaveDirPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaveDirPath.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBoxSaveDirPath.Location = new System.Drawing.Point(131, 555);
            this.textBoxSaveDirPath.Name = "textBoxSaveDirPath";
            this.textBoxSaveDirPath.Size = new System.Drawing.Size(902, 19);
            this.textBoxSaveDirPath.TabIndex = 6;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Azure;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(506, 469);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // buttonPolygon
            // 
            this.buttonPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPolygon.BackColor = System.Drawing.Color.White;
            this.buttonPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPolygon.ForeColor = System.Drawing.Color.Teal;
            this.buttonPolygon.Location = new System.Drawing.Point(1039, 122);
            this.buttonPolygon.Name = "buttonPolygon";
            this.buttonPolygon.Size = new System.Drawing.Size(84, 41);
            this.buttonPolygon.TabIndex = 14;
            this.buttonPolygon.Text = "Polygon";
            this.buttonPolygon.UseVisualStyleBackColor = false;
            this.buttonPolygon.Click += new System.EventHandler(this.buttonPolygon_Click);
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxImagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImagePath.Location = new System.Drawing.Point(126, 522);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.Size = new System.Drawing.Size(890, 19);
            this.textBoxImagePath.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(12, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Loaded Image";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadImage.BackColor = System.Drawing.Color.White;
            this.buttonLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadImage.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonLoadImage.Location = new System.Drawing.Point(1022, 519);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(101, 27);
            this.buttonLoadImage.TabIndex = 17;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = false;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTriangle.BackColor = System.Drawing.Color.White;
            this.buttonTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonTriangle.ForeColor = System.Drawing.Color.Teal;
            this.buttonTriangle.Location = new System.Drawing.Point(1039, 30);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(84, 40);
            this.buttonTriangle.TabIndex = 18;
            this.buttonTriangle.Text = "Triangle";
            this.buttonTriangle.UseVisualStyleBackColor = false;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonTetragon
            // 
            this.buttonTetragon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTetragon.BackColor = System.Drawing.Color.White;
            this.buttonTetragon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTetragon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonTetragon.ForeColor = System.Drawing.Color.Teal;
            this.buttonTetragon.Location = new System.Drawing.Point(1039, 76);
            this.buttonTetragon.Name = "buttonTetragon";
            this.buttonTetragon.Size = new System.Drawing.Size(84, 40);
            this.buttonTetragon.TabIndex = 19;
            this.buttonTetragon.Text = "Tetragon";
            this.buttonTetragon.UseVisualStyleBackColor = false;
            this.buttonTetragon.Click += new System.EventHandler(this.buttonTetragon_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(1039, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 40);
            this.button2.TabIndex = 21;
            this.button2.Text = "Ellipse";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonNothing
            // 
            this.buttonNothing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNothing.BackColor = System.Drawing.Color.White;
            this.buttonNothing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNothing.ForeColor = System.Drawing.Color.Teal;
            this.buttonNothing.Location = new System.Drawing.Point(1039, 1);
            this.buttonNothing.Name = "buttonNothing";
            this.buttonNothing.Size = new System.Drawing.Size(84, 23);
            this.buttonNothing.TabIndex = 22;
            this.buttonNothing.UseVisualStyleBackColor = false;
            this.buttonNothing.Click += new System.EventHandler(this.buttonNothing_Click);
            // 
            // flowLayoutPanelContour
            // 
            this.flowLayoutPanelContour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelContour.AutoScroll = true;
            this.flowLayoutPanelContour.BackColor = System.Drawing.Color.Azure;
            this.flowLayoutPanelContour.Location = new System.Drawing.Point(512, 1);
            this.flowLayoutPanelContour.Name = "flowLayoutPanelContour";
            this.flowLayoutPanelContour.Size = new System.Drawing.Size(504, 468);
            this.flowLayoutPanelContour.TabIndex = 23;
            // 
            // buttonGenerateContours
            // 
            this.buttonGenerateContours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateContours.BackColor = System.Drawing.Color.White;
            this.buttonGenerateContours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateContours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateContours.ForeColor = System.Drawing.Color.Teal;
            this.buttonGenerateContours.Location = new System.Drawing.Point(1039, 215);
            this.buttonGenerateContours.Name = "buttonGenerateContours";
            this.buttonGenerateContours.Size = new System.Drawing.Size(84, 46);
            this.buttonGenerateContours.TabIndex = 24;
            this.buttonGenerateContours.Text = "Generate Contours";
            this.buttonGenerateContours.UseVisualStyleBackColor = false;
            this.buttonGenerateContours.Click += new System.EventHandler(this.buttonGenerateContours_Click);
            // 
            // ContourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1128, 581);
            this.Controls.Add(this.buttonGenerateContours);
            this.Controls.Add(this.flowLayoutPanelContour);
            this.Controls.Add(this.buttonNothing);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonTetragon);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.buttonPolygon);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.textBoxSaveDirPath);
            this.Controls.Add(this.buttonOpenSaveDir);
            this.Controls.Add(this.buttonSetSaveDir);
            this.Controls.Add(this.buttonSaveImage);
            this.Name = "ContourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contour";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContourForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContourForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonSetSaveDir;
        private System.Windows.Forms.Button buttonOpenSaveDir;
        private System.Windows.Forms.TextBox textBoxSaveDirPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonPolygon;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonTetragon;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNothing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContour;
        private System.Windows.Forms.Button buttonGenerateContours;
    }
}

