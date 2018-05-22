using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public abstract class ContourCreator: ContourOperator
    {
        protected Marker _marker;
        protected Type ContourType;

        protected bool _creatingContour;


        protected abstract void AddMarker(Point point);
        protected abstract void RemoveUnusedMarkers();
        protected abstract void AddEvents();
        protected abstract void RemoveEvents();

        public void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            AddMarker(new Point(e.X, e.Y));
        }

        public void Marker_MouseClick(object sender, MouseEventArgs e)
        {
             Marker marker = (sender as Marker);
             AddMarker(new Point(marker.Location.X + e.X, marker.Location.Y + e.Y));
            //mouse click scenarios think about them
        }

        public void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
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
                AddMarker(Point.Empty);

                _selectedRect = Rectangle.Empty;
            }
        }

        protected void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                DrawSelection(e);
                _contourMap.DrawContours(e);
            }
        }

        private void DrawSelection(PaintEventArgs e)
        {
            if (_selectedRect != Rectangle.Empty && _selectedRect.Width > 0 && _selectedRect.Height > 0)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(128, 72, 145, 220)), _selectedRect);
            }
        }

        public override void RemoveResources()
        {
            RemoveEvents();
            RemoveUnusedMarkers();
        }
    }
}
