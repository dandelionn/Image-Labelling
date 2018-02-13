using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class Marker : UserControl
    {
        public Point CenterPosition { get; set;}

        public bool canBeMoved;
        public bool CanBeMoved
        {
            get { return canBeMoved; }
            set
            {
                canBeMoved = value;
                if (value == true)
                {
                    this.MouseDown += Marker_MouseDown;
                    this.MouseUp += Marker_MouseUp;
                    this.MouseMove += Marker_MouseMove;
                }
                else
                {
                    this.MouseDown -= Marker_MouseDown;
                    this.MouseUp -= Marker_MouseUp;
                    this.MouseMove -= Marker_MouseMove;
                }
            }
        } 

        public Marker()
        {
            InitializeComponent();
            SetCenterPosition();

        }

        private void SetCenterPosition()
        {
            CenterPosition = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
        }

        private void Marker_LocationChanged(object sender, EventArgs e)
        {
            SetCenterPosition();
        }

        private void Marker_SizeChanged(object sender, EventArgs e)
        {
            SetCenterPosition();
        }

        Point _initialPosition;
        bool _isMouseMoving = false;
        Point _previousMouseLocation;
        public void Marker_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseMoving)
            {
                Marker marker = sender as Marker;
                int newX = marker.Location.X + (Cursor.Position.X - _previousMouseLocation.X);
                int newY = marker.Location.Y + (Cursor.Position.Y - _previousMouseLocation.Y);
                marker.Location = new Point( newX, newY);

                Console.WriteLine("Message: " + e.Location.X + " " + e.Location.Y);

                _previousMouseLocation = Cursor.Position;

                marker.Parent.Invalidate();
            }
        }

        public void Marker_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMouseMoving == true) //atunci cand se construieste un polygon evenimentul aceste este captat si este schimbata pozitie markerului de aceea acest if
            {
                _isMouseMoving = false;

                Marker marker = sender as Marker;
                int X = marker.Location.X + (Cursor.Position.X - _previousMouseLocation.X);
                int Y = marker.Location.Y + (Cursor.Position.Y - _previousMouseLocation.Y);

                if ((X >= 0 && Y >= 0) && (X < (marker.Parent as PictureBox).Image.Size.Width && Y < (marker.Parent as PictureBox).Image.Size.Height))
                {
                    marker.Location = new Point(X, Y);
                }
                else
                {
                    marker.Location = _initialPosition;
                }

                marker.Parent.Invalidate();
            }
        }

        public void Marker_MouseDown(object sender, MouseEventArgs e)
        {
            _previousMouseLocation = Cursor.Position;
            _isMouseMoving = true;

            Marker marker = sender as Marker;
            int X = marker.Location.X + (Cursor.Position.X - _previousMouseLocation.X);
            int Y = marker.Location.Y + (Cursor.Position.Y - _previousMouseLocation.Y);
            _initialPosition = new Point(X, Y);
        }
    }
}
