using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class MaskGenerator
    {
        Point _center;

        List<Point> _dequeueNorth = new List<Point>();
        List<Point> _dequeueWest = new List<Point>();
        List<Point> _points = new List<Point>();

        private static MaskGenerator Instance;

        public static MaskGenerator GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MaskGenerator();
            }

            return Instance;
        }

        private MaskGenerator()
        {
        }

        public void Mark(int[,] mask, Point startPoint, int id, int width, int height)
        {
            try
            {
                Stack<Point> stack = new Stack<Point>();

                stack.Push(startPoint);

                Point currentPoint;
                int x, y;
                while (stack.Count > 0)
                {
                    currentPoint = stack.Pop();
                    x = currentPoint.X;
                    y = currentPoint.Y;
                    mask[x, y] = id;

                    if (x > 0 && x < width - 1 && y > 0 && y < height - 1)
                    {
                        if (mask[x - 1, y] == 0)
                        {
                            stack.Push(new Point(x - 1, y));
                        }
                        if (mask[x, y - 1] == 0)
                        {
                            stack.Push(new Point(x, y - 1));
                        }
                        if (mask[x + 1, y] == 0)
                        {
                            stack.Push(new Point(x + 1, y));
                        }
                        if (mask[x, y + 1] == 0)
                        {
                            stack.Push(new Point(x, y + 1));
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("OutOfMemoryException");
            }
        }

        public void AddContourToMask(int[,] contourMask, Contour contour, int _contourIndex)
        {
            if (contour is Ellipse)
            {
                DrawEllipse(contourMask, contour, _contourIndex);
            }
            else
            {
                for (int i = 0; i < contour.Markers.Count - 1; i++)
                {
                    DrawLine(contourMask, contour.Markers[i].CenterPosition, contour.Markers[i + 1].CenterPosition, _contourIndex);
                }

                DrawLine(contourMask, contour.Markers[0].CenterPosition, contour.Markers[contour.Markers.Count - 1].CenterPosition, _contourIndex);
            }
        }

        private void DrawLine(int[,] contourMask, Point A, Point B, int _contourIndex)
        {
            IEnumerable<Point> enumerator = EnumerateLineNoDiagonalSteps(A.X, A.Y, B.X, B.Y);

            foreach (Point point in enumerator)
            {
                contourMask[point.X, point.Y] = _contourIndex;
            }
        }

        //brehensam line algorithm
        private static IEnumerable<Point> EnumerateLineNoDiagonalSteps(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = dx + dy, e2;

            while (true)
            {
                yield return new Point(x0, y0);

                if (x0 == x1 && y0 == y1) break;

                e2 = 2 * err;

                // EITHER horizontal OR vertical step (but not both!)
                if (e2 > dy)
                {
                    err += dy;
                    x0 += sx;
                }
                else if (e2 < dx)
                { // <--- this "else" makes the difference
                    err += dx;
                    y0 += sy;
                }
            }
        }

        public void DrawEllipse(int[,] contourMask, Contour contour, int _contourIndex)
        {
            _dequeueNorth.Clear();
            _dequeueWest.Clear();
            _points.Clear();


            float x, y;
            double angle;
            int xc, yc;

            int a, b;  //ellipse parameters

            double p1, p2;

            _center = contour.Markers[0].CenterPosition;
            xc = _center.X;
            yc = _center.Y;

            a = (int)Math.Round(Geometry.EuclidianDistance(contour.Markers[1].CenterPosition, contour.Markers[2].CenterPosition)) / 2;
            b = (int)Math.Round(Geometry.EuclidianDistance(contour.Markers[3].CenterPosition, contour.Markers[4].CenterPosition)) / 2;
            angle = Geometry.ComputeEllipseAngle(contour.Markers[1].CenterPosition, contour.Markers[2].CenterPosition);
            angle = -angle;
            x = 0; y = b;

            _dequeueNorth.Add(Geometry.RotatePointAroundOrigin(angle, x, y));

            p1 = (b * b) - (a * a * b) + (a * a) / 4;

            while ((2.0 * b * b * x) <= (2.0 * a * a * y))
            {
                x++;
                if (p1 <= 0)
                {
                    p1 = p1 + (2.0 * b * b * x) + (b * b);
                }
                else
                {
                    y--;
                    p1 = p1 + (2.0 * b * b * x) + (b * b) - (2.0 * a * a * y);
                }

                _dequeueNorth.Add(Geometry.RotatePointAroundOrigin(angle, x, y));
                x = -x;

                _dequeueNorth.Insert(0, Geometry.RotatePointAroundOrigin(angle, x, y));
                x = -x;
            }

            x = a;
            y = 0;

            _dequeueWest.Add(Geometry.RotatePointAroundOrigin(angle, x, y));

            p2 = (a * a) + 2.0 * (b * b * a) + (b * b) / 4;
            while ((2.0 * b * b * x) > (2.0 * a * a * y))
            {
                y++;
                if (p2 > 0)
                {
                    p2 = p2 + (a * a) - (2.0 * a * a * y);
                }
                else
                {
                    x--;
                    p2 = p2 + (2.0 * b * b * x) - (2.0 * a * a * y) + (a * a);
                }

                _dequeueWest.Insert(0, Geometry.RotatePointAroundOrigin(angle, x, y));
                y = -y;

                _dequeueWest.Add(Geometry.RotatePointAroundOrigin(angle, x, y));
                y = -y;
            }

            _points.InsertRange(0, _dequeueNorth);
            _points.InsertRange(_points.Count, _dequeueWest);

            int n = _points.Count;
            for (int i = 0; i < n; i++)
            {
                _points.Add(new Point(xc + _points[i].X, yc - _points[i].Y));
                _points[i] = new Point(xc - _points[i].X, yc + _points[i].Y);
            }

            DrawPixels(contourMask, _contourIndex);
            contourMask[_center.X, _center.Y] = _contourIndex;
        }

        private void DrawPixels(int[,] contourMask, int _contourIndex)
        {
            //aplying brehensam line algorithm just to be sure that the ellipse is not having holes in it's contour
            for (int i = 0; i < _points.Count - 1; i++)
            {
                DrawLine(contourMask, _points[i], _points[i + 1], _contourIndex);
            }

            DrawLine(contourMask, _points[0], _points[_points.Count - 1], _contourIndex);
        }
    }
}
