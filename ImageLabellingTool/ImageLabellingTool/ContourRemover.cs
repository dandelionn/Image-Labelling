using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class ContourRemover: ContourOperator
    { 
        public ContourRemover(PictureBox pictureBox)
        {
            PictureBox = pictureBox;

            AddEvents();
        }

        private void AddEvents()
        {
            PictureBox.MouseUp += PictureBox_MouseUp;
            PictureBox.MouseMove += PictureBox_MouseMove;
            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.Paint += PictureBox_Paint;
        }

        public Rectangle ComputeRectInfo(Point tempEndPoint)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
            rectangle.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));

            return rectangle;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                DrawSelection(e);
                _contourMap.DrawContours(e);
            }
        }

        private void DrawSelection(PaintEventArgs e)
        {
            if (_selectedRect != null && _selectedRect.Width > 0 && _selectedRect.Height > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 72, 145, 220)), _selectedRect);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _selectedRect = ComputeRectInfo(e.Location);
            PictureBox.Invalidate();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _rectStartPoint = e.Location;
            _selectedRect = ComputeRectInfo(e.Location);
            PictureBox.Invalidate();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            for(int i=0; i < _contourMap.Contours.Count; i++)
            {
                foreach(Marker marker in _contourMap.Contours[i].Markers)
                {
                    if (IsMarkerInsidedRectangle(marker))
                    {
                        _contourMap.RemoveContour(_contourMap.Contours[i]);
                        i--;
                        break;
                    }
                }
            }

            PictureBox.Invalidate();
        }

        public void Clear()
        {
            _contourMap.Clear();
            PictureBox.Invalidate();
        }

        private bool IsMarkerInsidedRectangle(Marker marker)
        {
            if (marker.Location.X >= _selectedRect.X && marker.Location.X <= (_selectedRect.X + _selectedRect.Width) &&
                marker.Location.Y >= _selectedRect.Y && marker.Location.Y <= (_selectedRect.Y + _selectedRect.Height))
            {
                return true; 
            }

            return false;
        }

        private void RemoveEvents()
        {
            PictureBox.MouseUp -= PictureBox_MouseUp;
            PictureBox.MouseMove -= PictureBox_MouseMove;
            PictureBox.MouseDown -= PictureBox_MouseDown;
            PictureBox.Paint -= PictureBox_Paint;
        }

        public override void RemoveResources()
        {
            RemoveEvents();
        }
    }
}
