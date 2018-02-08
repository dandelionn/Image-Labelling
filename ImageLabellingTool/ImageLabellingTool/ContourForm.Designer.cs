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
            this.label1 = new System.Windows.Forms.Label();
            this.labelCropSize = new System.Windows.Forms.Label();
            this.buttonSetSaveDir = new System.Windows.Forms.Button();
            this.buttonOpenSaveDir = new System.Windows.Forms.Button();
            this.textBoxSaveDirPath = new System.Windows.Forms.TextBox();
            this.buttonCropEllipse = new System.Windows.Forms.Button();
            this.buttonCropRectangle = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOpenImage = new System.Windows.Forms.Button();
            this.buttonCropTriangle = new System.Windows.Forms.Button();
            this.buttonCropSquare = new System.Windows.Forms.Button();
            this.buttonCropCircle = new System.Windows.Forms.Button();
            this.buttonPolygon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveImage.BackColor = System.Drawing.Color.White;
            this.buttonSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveImage.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonSaveImage.Location = new System.Drawing.Point(519, 426);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(84, 43);
            this.buttonSaveImage.TabIndex = 1;
            this.buttonSaveImage.Text = "save";
            this.buttonSaveImage.UseVisualStyleBackColor = false;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(5, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "crop size";
            // 
            // labelCropSize
            // 
            this.labelCropSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCropSize.AutoSize = true;
            this.labelCropSize.BackColor = System.Drawing.Color.White;
            this.labelCropSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCropSize.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelCropSize.Location = new System.Drawing.Point(92, 512);
            this.labelCropSize.Name = "labelCropSize";
            this.labelCropSize.Size = new System.Drawing.Size(37, 20);
            this.labelCropSize.TabIndex = 3;
            this.labelCropSize.Text = "0x0";
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
            this.buttonOpenSaveDir.Location = new System.Drawing.Point(519, 552);
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
            this.textBoxSaveDirPath.Size = new System.Drawing.Size(382, 19);
            this.textBoxSaveDirPath.TabIndex = 6;
            // 
            // buttonCropEllipse
            // 
            this.buttonCropEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCropEllipse.BackColor = System.Drawing.Color.White;
            this.buttonCropEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCropEllipse.ForeColor = System.Drawing.Color.CadetBlue;
            this.buttonCropEllipse.Location = new System.Drawing.Point(519, 54);
            this.buttonCropEllipse.Name = "buttonCropEllipse";
            this.buttonCropEllipse.Size = new System.Drawing.Size(84, 43);
            this.buttonCropEllipse.TabIndex = 7;
            this.buttonCropEllipse.Text = "crop ellipse";
            this.buttonCropEllipse.UseVisualStyleBackColor = false;
            this.buttonCropEllipse.Click += new System.EventHandler(this.buttonCropEllipse_Click);
            // 
            // buttonCropRectangle
            // 
            this.buttonCropRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCropRectangle.BackColor = System.Drawing.Color.White;
            this.buttonCropRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCropRectangle.ForeColor = System.Drawing.Color.CadetBlue;
            this.buttonCropRectangle.Location = new System.Drawing.Point(519, 103);
            this.buttonCropRectangle.Name = "buttonCropRectangle";
            this.buttonCropRectangle.Size = new System.Drawing.Size(84, 43);
            this.buttonCropRectangle.TabIndex = 8;
            this.buttonCropRectangle.Text = "crop rectangle";
            this.buttonCropRectangle.UseVisualStyleBackColor = false;
            this.buttonCropRectangle.Click += new System.EventHandler(this.buttonCropRectangle_Click);
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
            this.flowLayoutPanel.Size = new System.Drawing.Size(190, 244);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // buttonOpenImage
            // 
            this.buttonOpenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenImage.BackColor = System.Drawing.Color.White;
            this.buttonOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenImage.ForeColor = System.Drawing.Color.Crimson;
            this.buttonOpenImage.Location = new System.Drawing.Point(519, 377);
            this.buttonOpenImage.Name = "buttonOpenImage";
            this.buttonOpenImage.Size = new System.Drawing.Size(84, 43);
            this.buttonOpenImage.TabIndex = 10;
            this.buttonOpenImage.Text = "open image";
            this.buttonOpenImage.UseVisualStyleBackColor = false;
            this.buttonOpenImage.Click += new System.EventHandler(this.buttonOpenImage_Click);
            // 
            // buttonCropTriangle
            // 
            this.buttonCropTriangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCropTriangle.BackColor = System.Drawing.Color.White;
            this.buttonCropTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCropTriangle.ForeColor = System.Drawing.Color.CadetBlue;
            this.buttonCropTriangle.Location = new System.Drawing.Point(519, 5);
            this.buttonCropTriangle.Name = "buttonCropTriangle";
            this.buttonCropTriangle.Size = new System.Drawing.Size(84, 43);
            this.buttonCropTriangle.TabIndex = 11;
            this.buttonCropTriangle.Text = "crop triangle";
            this.buttonCropTriangle.UseVisualStyleBackColor = false;
            this.buttonCropTriangle.Click += new System.EventHandler(this.buttonCropTriangle_Click);
            // 
            // buttonCropSquare
            // 
            this.buttonCropSquare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCropSquare.BackColor = System.Drawing.Color.White;
            this.buttonCropSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCropSquare.ForeColor = System.Drawing.Color.CadetBlue;
            this.buttonCropSquare.Location = new System.Drawing.Point(519, 152);
            this.buttonCropSquare.Name = "buttonCropSquare";
            this.buttonCropSquare.Size = new System.Drawing.Size(84, 43);
            this.buttonCropSquare.TabIndex = 12;
            this.buttonCropSquare.Text = "crop square";
            this.buttonCropSquare.UseVisualStyleBackColor = false;
            this.buttonCropSquare.Click += new System.EventHandler(this.buttonCropSquare_Click);
            // 
            // buttonCropCircle
            // 
            this.buttonCropCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCropCircle.BackColor = System.Drawing.Color.White;
            this.buttonCropCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCropCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCropCircle.ForeColor = System.Drawing.Color.CadetBlue;
            this.buttonCropCircle.Location = new System.Drawing.Point(519, 201);
            this.buttonCropCircle.Name = "buttonCropCircle";
            this.buttonCropCircle.Size = new System.Drawing.Size(84, 43);
            this.buttonCropCircle.TabIndex = 13;
            this.buttonCropCircle.Text = "crop circle";
            this.buttonCropCircle.UseVisualStyleBackColor = false;
            this.buttonCropCircle.Click += new System.EventHandler(this.buttonCropCircle_Click);
            // 
            // buttonPolygon
            // 
            this.buttonPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPolygon.BackColor = System.Drawing.Color.White;
            this.buttonPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPolygon.ForeColor = System.Drawing.Color.Teal;
            this.buttonPolygon.Location = new System.Drawing.Point(519, 281);
            this.buttonPolygon.Name = "buttonPolygon";
            this.buttonPolygon.Size = new System.Drawing.Size(84, 43);
            this.buttonPolygon.TabIndex = 14;
            this.buttonPolygon.Text = "Polygon";
            this.buttonPolygon.UseVisualStyleBackColor = false;
            this.buttonPolygon.Click += new System.EventHandler(this.buttonPolygon_Click);
            // 
            // ContourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(608, 581);
            this.Controls.Add(this.buttonPolygon);
            this.Controls.Add(this.buttonCropCircle);
            this.Controls.Add(this.buttonCropSquare);
            this.Controls.Add(this.buttonCropTriangle);
            this.Controls.Add(this.buttonOpenImage);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.buttonCropRectangle);
            this.Controls.Add(this.buttonCropEllipse);
            this.Controls.Add(this.textBoxSaveDirPath);
            this.Controls.Add(this.buttonOpenSaveDir);
            this.Controls.Add(this.buttonSetSaveDir);
            this.Controls.Add(this.labelCropSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveImage);
            this.Name = "ContourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contour";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContourForm_FormClosed);
            this.Load += new System.EventHandler(this.ContourForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ContourForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContourForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCropSize;
        private System.Windows.Forms.Button buttonSetSaveDir;
        private System.Windows.Forms.Button buttonOpenSaveDir;
        private System.Windows.Forms.TextBox textBoxSaveDirPath;
        private System.Windows.Forms.Button buttonCropEllipse;
        private System.Windows.Forms.Button buttonCropRectangle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonOpenImage;
        private System.Windows.Forms.Button buttonCropTriangle;
        private System.Windows.Forms.Button buttonCropSquare;
        private System.Windows.Forms.Button buttonCropCircle;
        private System.Windows.Forms.Button buttonPolygon;
    }
}

