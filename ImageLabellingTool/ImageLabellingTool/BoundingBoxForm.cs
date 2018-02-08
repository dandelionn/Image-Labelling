using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCropper
{
    public partial class BoundingBoxForm : Form
    {
        public BoundingBoxForm()
        {
            InitializeComponent();
        }

        private void BoundingBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
