using System;
using System.Drawing;

namespace ImageLabellingTool
{
    public static class Geometry
    {

        public static Point RotatePointAroundOrigin(double angle, double x, double y)
        {
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);

            // rotate point
            double xnew = x * c - y * s;
            double ynew = x * s + y * c;

            return new Point((int)Math.Round(xnew), (int)Math.Round(ynew));
        }

        public static Rectangle ComputeRectInfo(Point rectStartPoint, Point tempEndPoint)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Location = new Point(Math.Min(rectStartPoint.X, tempEndPoint.X), Math.Min(rectStartPoint.Y, tempEndPoint.Y));
            rectangle.Size = new Size(Math.Abs(rectStartPoint.X - tempEndPoint.X), Math.Abs(rectStartPoint.Y - tempEndPoint.Y));

            return rectangle;
        }

        public static Point FindInsidePoint(Contour contour)
        {
            Point gravityCenter = new Point();

            if (contour is Ellipse)
            {
                gravityCenter.X = contour.Markers[0].CenterPosition.X;
                gravityCenter.Y = contour.Markers[0].CenterPosition.Y;
            }
            else
            {

                int valid;
                for (int i = 0; i < contour.Markers.Count - 2; i++)
                {
                    valid = 0;

                    if (!Geometry.AreCollinearPoints(contour.Markers[i].CenterPosition, contour.Markers[i + 1].CenterPosition, contour.Markers[i + 2].CenterPosition))
                    {
                        gravityCenter.X = (contour.Markers[i].CenterPosition.X + contour.Markers[i + 1].CenterPosition.X + contour.Markers[i + 2].CenterPosition.X) / 3;
                        gravityCenter.Y = (contour.Markers[i].CenterPosition.Y + contour.Markers[i + 1].CenterPosition.Y + contour.Markers[i + 2].CenterPosition.Y) / 3;

                        for (int j = 0; j < contour.Markers.Count - 1; j++)
                        {
                            valid += IsPointLineInstersectingTargetLine(gravityCenter, contour.Markers[j].CenterPosition, contour.Markers[j + 1].CenterPosition);
                        }

                        valid += IsPointLineInstersectingTargetLine(gravityCenter, contour.Markers[0].CenterPosition, contour.Markers[contour.Markers.Count - 1].CenterPosition);

                        if (valid % 2 == 1)
                        {
                            return gravityCenter;
                        }
                    }
                }
            }

            return gravityCenter;
        }

        private static int IsPointLineInstersectingTargetLine(Point point, Point A, Point B)
        {
            //it is enough to test only the segments situated on the right side of the point
            if (point.X > A.X && point.X > B.X)  //segment situated on the left side
            {
                return 0;
            }

            if ((point.Y > A.Y && point.Y < B.Y) || (point.Y > B.Y && point.Y < A.Y))
            {
                if (A.Y < B.Y)
                {
                    if (Geometry.CrossProduct(A, B, point) == -1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (Geometry.CrossProduct(B, A, point) == -1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        public static Point RotatePointAroundOrigin(Point centerPoint, double angle, Point point)
        {
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);

            //translate to origin
            double x = point.X - centerPoint.X;
            double y = point.Y - centerPoint.Y;

            // rotate point
            double xnew = x * c - y * s;
            double ynew = x * s + y * c;

            //translate back to original position
            xnew = xnew + centerPoint.X;
            ynew = ynew + centerPoint.Y;

            return new Point((int)Math.Round(xnew), (int)Math.Round(ynew));
        }


        public static bool AreCollinearPoints(Point A, Point B, Point C)
        {
            if (B.X == A.X && C.X == B.X)
            {
                return true;
            }

            double angle = Geometry.Angle(A, B, C);

            if (angle > 15 && angle < 165)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //angle between two vectors
        public static double Angle(Point A, Point B, Point C)
        {
            //vector AB
            double x1 = B.X - A.X;
            double y1 = B.Y - A.Y;

            //vector BC
            double x2 = B.X - C.X;
            double y2 = B.Y - C.Y;

            double cosAngle = (x1 * x2 + y1 * y2) / (Math.Sqrt(x1 * x1 + y1 * y1) * Math.Sqrt(x2 * x2 + y2 * y2));

            return Math.Acos(cosAngle) * 180 / Math.PI;
        }

        public static Point RotatePointAroundPoint(Point centerPoint, double angle, Point point)
        {
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);

            //translate to origin
            double x = point.X - centerPoint.X;
            double y = point.Y - centerPoint.Y;

            // rotate point
            double xnew = x * c - y * s;
            double ynew = x * s + y * c;

            //translate back to original position
            xnew = xnew + centerPoint.X;
            ynew = ynew + centerPoint.Y;

            return new Point((int)Math.Round(xnew), (int)Math.Round(ynew));
        }


        public static double Slope(Point A, Point B)
        {
            return ((double)B.Y - (double)A.Y) / ((double)B.X - (double)A.X);
        }

        public static int CrossProduct(Point A, Point B, Point P)
        {
            //Use the sign of the determinant of vectors(AB, AM), where P(X, Y) is the query point:
            return Math.Sign((B.X - A.X) * (P.Y - A.Y) - (B.Y - A.Y) * (P.X - A.X));
            //It is 0 on the line, and + 1 on one side, -1 on the other side.
        }


        public static double ComputeEllipseAngle(Point A, Point B)
        {
            Point auxPoint = new Point(A.X + 100, A.Y);

            double b = EuclidianDistance(A, B);
            double c = EuclidianDistance(A, auxPoint);
            double a = EuclidianDistance(auxPoint, B);
            double cos = (b * b + c * c - a * a) / (2 * b * c);

            if (A.Y > B.Y)
            {
                return -Math.Acos(cos);
            }
            else
            {

                return Math.Acos(cos);
            }
        }

        public static double EuclidianDistance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }


        public static Point FindProjectionPoint(Point A, Point B, Point P)
        {
            if (A.Y == B.Y) //HORIZONTAL
            {
                return new Point(P.X, A.Y);
            }
            if (A.X == B.X) //VERTICAL 
            {
                return new Point(A.X, P.Y);
            }

            double mAB = ((double)B.Y - (double)A.Y) / ((double)B.X - (double)A.X);
            double mP = -((double)B.X - (double)A.X) / ((double)B.Y - (double)A.Y);
            double bAB = (double)A.Y - mAB * (double)A.X;
            double bP = (double)P.Y - mP * (double)P.X;
            double x = (bP - bAB) / (mAB - mP);
            double y = mAB * x + bAB;

            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }
    }
}
