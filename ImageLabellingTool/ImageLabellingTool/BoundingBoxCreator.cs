
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageLabellingTool
{


    public class BoundingBoxCreator
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        PictureBox PictureBox;
        protected Point _rectStartPoint;
        protected Rectangle _selectedRect;

        public BoundingBoxCreator(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.MouseMove += PictureBox_MouseMove;
            PictureBox.MouseUp += PictureBox_MouseUp;
            PictureBox.Paint += PictureBox_Paint;

            AllocConsole();
        }

        public void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedRect = Rectangle.Empty;
            _rectStartPoint = e.Location;
        }

        protected void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _selectedRect = Geometry.ComputeRectInfo(_rectStartPoint, e.Location);
            PictureBox.Invalidate();
        }

        protected void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               // _selectedRect = Rectangle.Empty;
            }
        }

        protected void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {      
                DrawSelection(e);
            }
        }

        private void DrawSelection(PaintEventArgs e)
        {    
            if (_selectedRect != Rectangle.Empty && _selectedRect.Width > 0 && _selectedRect.Height > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 72, 145, 220)), _selectedRect);
            }
        }
    }
}
