using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class Marker : UserControl
    {
        public Point CenterPosition { get; set;}
        public Contour Contour { get; set; }
        public bool IsFocused { get; set; }
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

                    if (Contour is Ellipse)
                    {
                        this.GotFocus += Marker_GotFocus;
                        this.LostFocus += Marker_LostFocus;
                    }
                }
                else
                {
                    this.MouseDown -= Marker_MouseDown;
                    this.MouseUp -= Marker_MouseUp;
                    this.MouseMove -= Marker_MouseMove;


                    if (Contour is Ellipse)
                    {
                        this.GotFocus -= Marker_GotFocus;
                        this.LostFocus -= Marker_LostFocus;
                    }
                }
            }
        }

        private void Marker_LostFocus(object sender, EventArgs e)
        {
            IsFocused = false;
            for (int i = 5; i < 9; i++)
            {
                Contour.Markers[i].Hide();
            }
        }

        private void Marker_GotFocus(object sender, EventArgs e)
        {
            IsFocused = true;
          
            for (int i = 5; i < 9; i++)
            {
                Contour.Markers[i].Show();
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

                int dx = 0, dy = 0;
                ComputeDelta(marker, ref dx, ref dy);

                if (Contour is Ellipse)
                {
                    if (marker == Contour.Markers[1] || marker == Contour.Markers[2] || marker == Contour.Markers[3] || marker == Contour.Markers[4])
                    {
                        Point projectionPoint = Geometry.FindProjectionPoint(Contour.Markers[0].Location, marker.Location, GetCursorPoint(marker));
                        marker.Location = projectionPoint;
                    }
                    else
                    {
                        if (marker == Contour.Markers[0])
                        {
                            int newX = marker.Location.X + dx;
                            int newY = marker.Location.Y + dy;

                            marker.Location = new Point(newX, newY);
                        }
                    }
                }
                else
                {
                    int newX = marker.Location.X + dx;
                    int newY = marker.Location.Y + dy;

                    marker.Location = new Point(newX, newY);
                }

                if (Contour is Ellipse)
                {
                    ModifyEllipse(marker, dx, dy);
                }
    
                _previousMouseLocation = Cursor.Position;

                marker.Parent.Invalidate();
            }
        }

        public Point GetCursorPoint(Marker marker)
        {
            PictureBox pictureBox = (marker.Parent as PictureBox);
            Point point = new Point();
            point.X = Cursor.Position.X - pictureBox.PointToScreen(Point.Empty).X;
            point.Y = Cursor.Position.Y - pictureBox.PointToScreen(Point.Empty).Y;

            return point;
        }

        public void Marker_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMouseMoving == true) //atunci cand se construieste un polygon evenimentul aceste este captat si este schimbata pozitie markerului de aceea acest if
            {
                _isMouseMoving = false;

                Marker marker = sender as Marker;

                int dx = 0, dy = 0;
                ComputeDelta(marker, ref dx, ref dy);

                if (Contour is Ellipse)
                {
                    if(marker == Contour.Markers[1] || marker == Contour.Markers[2] || marker == Contour.Markers[3] || marker == Contour.Markers[4])
                    {
                        Point projectionPoint = Geometry.FindProjectionPoint(Contour.Markers[0].Location, marker.Location, GetCursorPoint(marker));


                        if (IsPointInsideBounds((marker.Parent as PictureBox), projectionPoint))
                        {
                            marker.Location = projectionPoint;
                        }
                        else
                        {
                            marker.Location = _initialPosition;
                        }
                    }
                    else
                    {
                        if (marker == Contour.Markers[0])
                        {
                            int X = marker.Location.X + dx;
                            int Y = marker.Location.Y + dy;

                            if ((X >= 0 && Y >= 0) && (X < (marker.Parent as PictureBox).Image.Size.Width && Y < (marker.Parent as PictureBox).Image.Size.Height))
                            {
                                marker.Location = new Point(X, Y);
                            }
                            else
                            {
                                marker.Location = _initialPosition;
                            }
                        }
                    }
                }
                else
                {
                    int X = marker.Location.X + dx;
                    int Y = marker.Location.Y + dy;

                    if ((X >= 0 && Y >= 0) && (X < (marker.Parent as PictureBox).Image.Size.Width && Y < (marker.Parent as PictureBox).Image.Size.Height))
                    {
                        marker.Location = new Point(X, Y);
                    }
                    else
                    {
                        marker.Location = _initialPosition;
                    }
                }

                if(Contour is Ellipse)
                {
                    ModifyEllipse(marker, dx, dy);
                }

                marker.Parent.Invalidate();
            }
        }

        public bool IsPointInsideBounds(PictureBox pictureBox, Point point)
        {
            return (point.X >= 0 && point.Y >= 0) && (point.X < pictureBox.Image.Size.Width && point.Y < pictureBox.Image.Size.Height);
        }

        void ComputeDelta(Marker marker, ref int dx, ref int dy)
        {
            dx = Cursor.Position.X - _previousMouseLocation.X;
            dy = Cursor.Position.Y - _previousMouseLocation.Y;
        }

        void ModifyEllipse(Marker marker, int dx, int dy)
        {
            if (marker == Contour.Markers[0])
            {
                for (int i = 1; i < Contour.Markers.Count; i++)
                {
                    Contour.Markers[i].Location = new Point(Contour.Markers[i].Location.X + dx, Contour.Markers[i].Location.Y + dy);
                }
            }

            else if (marker == Contour.Markers[1])
            {
                RebuildEllipseFromRight();
            }
            else if (marker == Contour.Markers[2])
            {
                RebuildEllipseFromLeft();
            }
            else if (marker == Contour.Markers[3])
            {
                RebuildEllipseFromDown();
            }
            else if (marker == Contour.Markers[4])
            {
                RebuildEllipseFromUp();
            }
            else if (marker == Contour.Markers[5] || marker == Contour.Markers[6] || marker == Contour.Markers[7] || marker == Contour.Markers[8])
            {
                int x = (Contour.Markers[1].Location.X + Contour.Markers[2].Location.X) / 2;
                int y = (Contour.Markers[1].Location.Y + Contour.Markers[2].Location.Y) / 2;

                Point center = new Point(x, y);

                double angle;
                Point A = Contour.Markers[1].Location;
                Point B;
                if (marker == Contour.Markers[5] || marker == Contour.Markers[6])
                {
                    B = new Point(Contour.Markers[2].Location.X - dx, Contour.Markers[2].Location.Y - dy);
                }
                else // if(marker == Contour.Markers[7] || marker == Contour.Markers[8])
                {
                    B = new Point(Contour.Markers[2].Location.X + dx, Contour.Markers[2].Location.Y + dy);
                }

                angle = Geometry.ComputeEllipseAngle(A, B);
                RebuildEllipse(center, angle);
            }
        }

        public void RebuildEllipseFromRight(double rotationAngle = 0)
        {
            Point right = Contour.Markers[2].Location;
            Point left, up, down, center;
            Point leftUp, leftDown, rightUp, rightDown;

            double x_radius = 0, y_radius = 0, angle = rotationAngle;
            ComputeEllipseParams(ref x_radius, ref y_radius, ref angle);

            
            center = new Point((int)Math.Round(right.X - x_radius/2), right.Y);
            left = new Point((int)Math.Round(right.X - x_radius), right.Y);
            up = new Point((int)Math.Round(right.X - x_radius/2), (int)Math.Round(right.Y - y_radius / 2));
            down = new Point((int)Math.Round(right.X - x_radius / 2), (int)Math.Round(right.Y + y_radius / 2));

            leftUp = new Point((int)Math.Round(right.X - x_radius), (int)Math.Round(right.Y - y_radius / 2));
            leftDown = new Point((int)Math.Round(right.X - x_radius), (int)Math.Round(right.Y + y_radius / 2));
            rightUp = new Point(right.X, (int)Math.Round(right.Y - y_radius / 2));
            rightDown = new Point(right.X, (int)Math.Round(right.Y + y_radius / 2));


            Contour.Markers[0].Location = Geometry.RotatePointAroundPoint(right, angle, center);
            Contour.Markers[1].Location = Geometry.RotatePointAroundPoint(right, angle, left);
            //Contour.Markers[2].Location = Geometry.RotatePointAroundPoint(right, angle, right);
            Contour.Markers[3].Location = Geometry.RotatePointAroundPoint(right, angle, up);
            Contour.Markers[4].Location = Geometry.RotatePointAroundPoint(right, angle, down);
            //rotation Markers
            Contour.Markers[5].Location = Geometry.RotatePointAroundPoint(right, angle, leftUp);
            Contour.Markers[6].Location = Geometry.RotatePointAroundPoint(right, angle, leftDown);
            Contour.Markers[7].Location = Geometry.RotatePointAroundPoint(right, angle, rightUp);
            Contour.Markers[8].Location = Geometry.RotatePointAroundPoint(right, angle, rightDown);
        }

        public void RebuildEllipseFromLeft(double rotationAngle = 0)
        {
            Point left = Contour.Markers[1].Location;
            Point right, up, down, center;
            Point leftUp, leftDown, rightUp, rightDown;

            double x_radius = 0, y_radius = 0, angle = rotationAngle;
            ComputeEllipseParams(ref x_radius, ref y_radius, ref angle);


            center = new Point((int)Math.Round(left.X + x_radius / 2), left.Y);
            right = new Point((int)Math.Round(left.X + x_radius), left.Y);
            up = new Point((int)Math.Round(left.X + x_radius / 2), (int)Math.Round(left.Y - y_radius / 2));
            down = new Point((int)Math.Round(left.X + x_radius / 2), (int)Math.Round(left.Y + y_radius / 2));

            leftUp = new Point(left.X, (int)Math.Round(left.Y - y_radius / 2));
            leftDown = new Point(left.X, (int)Math.Round(left.Y + y_radius / 2));
            rightUp = new Point((int)Math.Round(left.X + x_radius), (int)Math.Round(left.Y - y_radius / 2));
            rightDown = new Point((int)Math.Round(left.X + x_radius), (int)Math.Round(left.Y + y_radius / 2));

            Contour.Markers[0].Location = Geometry.RotatePointAroundPoint(left, angle, center);
            //Contour.Markers[1].Location = Geometry.RotatePointAroundPoint(right, angle, left);
            Contour.Markers[2].Location = Geometry.RotatePointAroundPoint(left, angle, right);
            Contour.Markers[3].Location = Geometry.RotatePointAroundPoint(left, angle, up);
            Contour.Markers[4].Location = Geometry.RotatePointAroundPoint(left, angle, down);
            //rotation Markers
            Contour.Markers[5].Location = Geometry.RotatePointAroundPoint(left, angle, leftUp);
            Contour.Markers[6].Location = Geometry.RotatePointAroundPoint(left, angle, leftDown);
            Contour.Markers[7].Location = Geometry.RotatePointAroundPoint(left, angle, rightUp);
            Contour.Markers[8].Location = Geometry.RotatePointAroundPoint(left, angle, rightDown);
        }

        public void RebuildEllipseFromUp(double rotationAngle = 0)
        {
            Point up = Contour.Markers[3].Location;
            Point left, right, down, center;
            Point leftUp, leftDown, rightUp, rightDown;

            double x_radius = 0, y_radius = 0, angle = rotationAngle;
            ComputeEllipseParams(ref x_radius, ref y_radius, ref angle);


            center = new Point(up.X, (int)Math.Round(up.Y + y_radius/2));
            left = new Point((int)Math.Round(up.X - x_radius / 2), (int)Math.Round(up.Y + y_radius / 2));
            right = new Point((int)Math.Round(up.X + x_radius / 2), (int)Math.Round(up.Y + y_radius / 2));
            down = new Point(up.X, (int)Math.Round(up.Y + y_radius));

            leftUp = new Point((int)Math.Round(up.X - x_radius / 2), up.Y);
            leftDown = new Point((int)Math.Round(up.X - x_radius / 2), (int)Math.Round(up.Y + y_radius));
            rightUp = new Point((int)Math.Round(up.X + x_radius / 2), up.Y);
            rightDown = new Point((int)Math.Round(up.X + x_radius / 2), (int)Math.Round(up.Y + y_radius));


            Contour.Markers[0].Location = Geometry.RotatePointAroundPoint(up, angle, center);
            Contour.Markers[1].Location = Geometry.RotatePointAroundPoint(up, angle, left);
            Contour.Markers[2].Location = Geometry.RotatePointAroundPoint(up, angle, right);
            //Contour.Markers[3].Location = Geometry.RotatePointAroundPoint(up, angle, up);
            Contour.Markers[4].Location = Geometry.RotatePointAroundPoint(up, angle, down);
            //rotation Markers
            Contour.Markers[5].Location = Geometry.RotatePointAroundPoint(up, angle, leftUp);
            Contour.Markers[6].Location = Geometry.RotatePointAroundPoint(up, angle, leftDown);
            Contour.Markers[7].Location = Geometry.RotatePointAroundPoint(up, angle, rightUp);
            Contour.Markers[8].Location = Geometry.RotatePointAroundPoint(up, angle, rightDown);
        }

        public void RebuildEllipseFromDown(double rotationAngle = 0)
        {
            Point down = Contour.Markers[4].Location;
            Point left, right, up, center;
            Point leftUp, leftDown, rightUp, rightDown;

            double x_radius = 0, y_radius = 0, angle = rotationAngle;
            ComputeEllipseParams(ref x_radius, ref y_radius, ref angle);

            center = new Point(down.X, (int)Math.Round(down.Y - y_radius / 2));
            left = new Point((int)Math.Round(down.X - x_radius / 2), (int)Math.Round(down.Y - y_radius / 2));
            right = new Point((int)Math.Round(down.X + x_radius / 2), (int)Math.Round(down.Y - y_radius / 2));
            up = new Point(down.X, (int)Math.Round(down.Y - y_radius));

            leftUp = new Point((int)Math.Round(down.X - x_radius / 2),(int)Math.Round(down.Y - y_radius));
            leftDown = new Point((int)Math.Round(down.X - x_radius / 2), down.Y);
            rightUp = new Point((int)Math.Round(down.X + x_radius / 2), (int)Math.Round(down.Y - y_radius));
            rightDown = new Point((int)Math.Round(down.X + x_radius / 2), down.Y);


            Contour.Markers[0].Location = Geometry.RotatePointAroundPoint(down, angle, center);
            Contour.Markers[1].Location = Geometry.RotatePointAroundPoint(down, angle, left);
            Contour.Markers[2].Location = Geometry.RotatePointAroundPoint(down, angle, right);
            Contour.Markers[3].Location = Geometry.RotatePointAroundPoint(down, angle, up);
            //Contour.Markers[4].Location = Geometry.RotatePointAroundPoint(down, angle, down);
            //rotation Markers
            Contour.Markers[5].Location = Geometry.RotatePointAroundPoint(down, angle, leftUp);
            Contour.Markers[6].Location = Geometry.RotatePointAroundPoint(down, angle, leftDown);
            Contour.Markers[7].Location = Geometry.RotatePointAroundPoint(down, angle, rightUp);
            Contour.Markers[8].Location = Geometry.RotatePointAroundPoint(down, angle, rightDown);
        }

 
        public void RebuildEllipse(Point center, double rotationAngle = 0)
        {
            Point left, right, up, down;
            Point leftUp, leftDown, rightUp, rightDown;

            double x_radius=0, y_radius=0, angle=rotationAngle;
            ComputeEllipseParams(ref x_radius, ref y_radius, ref angle);

            left = new Point((int)Math.Round(center.X - x_radius / 2), center.Y);
            right = new Point((int)Math.Round(center.X + x_radius / 2), center.Y);
            up = new Point(center.X, (int)Math.Round(center.Y - y_radius / 2));
            down = new Point(center.X, (int)Math.Round(center.Y + y_radius / 2));
            leftUp = new Point((int)Math.Round(center.X - x_radius / 2), (int)Math.Round(center.Y - y_radius / 2));
            leftDown = new Point((int)Math.Round(center.X - x_radius / 2), (int)Math.Round(center.Y + y_radius / 2));
            rightUp = new Point((int)Math.Round(center.X + x_radius / 2), (int)Math.Round(center.Y - y_radius / 2));
            rightDown = new Point((int)Math.Round(center.X + x_radius / 2), (int)Math.Round(center.Y + y_radius / 2));


            Contour.Markers[0].Location = center;
            Contour.Markers[1].Location = Geometry.RotatePointAroundOrigin(center, angle, left);
            Contour.Markers[2].Location = Geometry.RotatePointAroundOrigin(center, angle, right);
            Contour.Markers[3].Location = Geometry.RotatePointAroundOrigin(center, angle, up);
            Contour.Markers[4].Location = Geometry.RotatePointAroundOrigin(center, angle, down);
            //rotation Markers
            Contour.Markers[5].Location = Geometry.RotatePointAroundOrigin(center, angle, leftUp);
            Contour.Markers[6].Location = Geometry.RotatePointAroundOrigin(center, angle, leftDown);
            Contour.Markers[7].Location = Geometry.RotatePointAroundOrigin(center, angle, rightUp);
            Contour.Markers[8].Location = Geometry.RotatePointAroundOrigin(center, angle, rightDown);
        }

        public void ComputeEllipseParams(ref double x_radius, ref double y_radius, ref double angle)
        {
            x_radius = Geometry.EuclidianDistance(Contour.Markers[1].Location, Contour.Markers[2].Location);
            y_radius = Geometry.EuclidianDistance(Contour.Markers[3].Location, Contour.Markers[4].Location);


            if (angle == 0)
            {
                angle = Geometry.ComputeEllipseAngle(Contour.Markers[1].Location, Contour.Markers[2].Location);
            }

            if (Contour.Markers[1].Location.X > Contour.Markers[2].Location.X)
            {
                x_radius = -x_radius;
            }
            if (Contour.Markers[3].Location.Y > Contour.Markers[4].Location.Y)
            {
                y_radius = -y_radius;
            }
        }

        public void Marker_MouseDown(object sender, MouseEventArgs e)
        {
            Marker marker = sender as Marker;
   
            _isMouseMoving = true;

            _previousMouseLocation = Cursor.Position;

            _initialPosition = new Point(marker.Location.X, marker.Location.Y);
        }
    }
}
