using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class Nothing: ContourOperator
    {
        public Nothing(PictureBox pictureBox)
        {
            PictureBox = pictureBox;

            AddEvents();
        }

        private void AddEvents()
        {
            PictureBox.Paint += PictureBox_Paint;
        }

        private void RemoveEvents()
        {
            PictureBox.Paint -= PictureBox_Paint;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                _contourMap.DrawContours(e);
            }
        }

        public override void RemoveResources()
        {
            RemoveEvents();
        }
    }
}
