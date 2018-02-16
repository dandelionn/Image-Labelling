using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public abstract class ContourCreator
    {
        public PictureBox PictureBox { get; set; }
        protected ContourMap _contourMap;

        protected Marker _marker;
        protected Type ContourType;

        protected bool _creatingContour;

        private Point _rectStartPoint;
        protected Rectangle _selectedRect;

        protected abstract void AddMarker(Point point);

        public ContourCreator()
        {
            _contourMap = ContourMap.GetInstance();
        }

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
            _selectedRect = ComputeRectInfo(e.Location);
            PictureBox.Invalidate();
        }

        protected void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               // if (_selectedRect.Contains(e.Location))
                //{
                    AddMarker(Point.Empty);
                //}
            }
        }

        public Rectangle ComputeRectInfo(Point tempEndPoint)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
            rectangle.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));
    
            return rectangle;
        }

        public void PictureBox_Paint(object sender, PaintEventArgs e)
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
                e.Graphics.FillEllipse(Brushes.Red, _selectedRect);
            }
        }

        public void RemoveResources()
        {
            RemoveEvents();
            RemoveUnusedMarkers();
        }
    }
}
