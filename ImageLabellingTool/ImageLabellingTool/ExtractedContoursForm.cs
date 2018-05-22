
using System.Drawing;

using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class ExtractedContoursForm : Form
    {
        public ExtractedContoursForm(Image image)
        {
            InitializeComponent();
            SetImage(image);
        }

        public void SetImage(Image image)
        {
            pictureBox.Size = image.Size;
            pictureBox.Image = image;
        }
    }
}
