
using System.Windows.Forms;

namespace ImageCropper
{
    public partial class ClassificationForm : Form
    {
        public ClassificationForm()
        {
            InitializeComponent();
        }

        private void ClassificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
