namespace ImageLabellingTool
{
    partial class MenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClassification = new System.Windows.Forms.Button();
            this.buttonContour = new System.Windows.Forms.Button();
            this.buttonBoundingBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Task Type";
            // 
            // buttonClassification
            // 
            this.buttonClassification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClassification.BackColor = System.Drawing.Color.Gray;
            this.buttonClassification.Enabled = false;
            this.buttonClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClassification.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.buttonClassification.ForeColor = System.Drawing.Color.Black;
            this.buttonClassification.Location = new System.Drawing.Point(28, 77);
            this.buttonClassification.Name = "buttonClassification";
            this.buttonClassification.Size = new System.Drawing.Size(330, 54);
            this.buttonClassification.TabIndex = 1;
            this.buttonClassification.Text = "Classification";
            this.buttonClassification.UseVisualStyleBackColor = false;
            this.buttonClassification.Click += new System.EventHandler(this.buttonClassification_Click);
            // 
            // buttonContour
            // 
            this.buttonContour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContour.BackColor = System.Drawing.Color.DarkGray;
            this.buttonContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContour.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.buttonContour.ForeColor = System.Drawing.Color.Black;
            this.buttonContour.Location = new System.Drawing.Point(28, 147);
            this.buttonContour.Name = "buttonContour";
            this.buttonContour.Size = new System.Drawing.Size(330, 54);
            this.buttonContour.TabIndex = 2;
            this.buttonContour.Text = "Contour";
            this.buttonContour.UseVisualStyleBackColor = false;
            this.buttonContour.Click += new System.EventHandler(this.buttonContour_Click);
            // 
            // buttonBoundingBox
            // 
            this.buttonBoundingBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBoundingBox.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonBoundingBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBoundingBox.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoundingBox.ForeColor = System.Drawing.Color.Black;
            this.buttonBoundingBox.Location = new System.Drawing.Point(28, 218);
            this.buttonBoundingBox.Name = "buttonBoundingBox";
            this.buttonBoundingBox.Size = new System.Drawing.Size(330, 50);
            this.buttonBoundingBox.TabIndex = 3;
            this.buttonBoundingBox.Text = "Bounding Box";
            this.buttonBoundingBox.UseVisualStyleBackColor = false;
            this.buttonBoundingBox.Click += new System.EventHandler(this.buttonBoundingBox_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(379, 293);
            this.Controls.Add(this.buttonBoundingBox);
            this.Controls.Add(this.buttonContour);
            this.Controls.Add(this.buttonClassification);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Labelling Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClassification;
        private System.Windows.Forms.Button buttonContour;
        private System.Windows.Forms.Button buttonBoundingBox;
    }
}