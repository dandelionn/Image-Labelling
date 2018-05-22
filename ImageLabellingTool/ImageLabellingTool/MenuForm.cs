using System;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }


        private void buttonClassification_Click(object sender, EventArgs e)
        {
            ClassificationForm classificationForm = new ClassificationForm();
            classificationForm.Owner = this;
 
            classificationForm.Show();

            this.Hide();
        }

        private void buttonContour_Click(object sender, EventArgs e)
        {
            ContourForm contourForm = new ContourForm();
            contourForm.Owner = this;
            contourForm.Show();

            this.Hide();
        }

        private void buttonBoundingBox_Click(object sender, EventArgs e)
        {
            BoundingBoxForm boundingBoxForm = new BoundingBoxForm();
            boundingBoxForm.Owner = this;
            boundingBoxForm.Show();

            this.Hide();
        }
    }
}
