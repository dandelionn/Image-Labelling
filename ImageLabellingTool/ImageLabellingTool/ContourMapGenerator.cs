using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class ContourMapGenerator
    {
        private PictureBox _pictureBox { get; set; }
        private MaskGenerator _maskGenerator;


        private int[,] _contourMask;
        int _contourIndex;
        Marker _insidePoint;

        private static ContourMapGenerator Instance;

        public static ContourMapGenerator GetInstance(PictureBox pictureBox)
        {
            if (Instance == null)
            {
                Instance = new ContourMapGenerator(pictureBox);
            }

            return Instance;
        }

        private ContourMapGenerator(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _insidePoint = new Marker();
            _insidePoint.Parent = _pictureBox;
            _insidePoint.BackColor = Color.Yellow;
            _insidePoint.Size = new Size(4, 4);
            _insidePoint.Hide();

            _maskGenerator = MaskGenerator.GetInstance();
        }

        public void HideInsidePoint()
        {
            _insidePoint.Hide();
        }

        public void ShowInsidePoint()
        {
            _insidePoint.Show();
        }

        public Bitmap GenerateContourImage(Bitmap bitmap, List<Contour> contours)
        {
            _contourIndex = 1;
            _contourMask = new int[bitmap.Width, bitmap.Height];

            foreach (Contour contour in contours)
            {
                _maskGenerator.AddContourToMask(_contourMask, contour, _contourIndex);

                FillContour(_contourMask, contour, bitmap.Width, bitmap.Height);

                _contourIndex++;
            }

            return ExtractSectionsFromImage(bitmap, _contourMask);
        }

        private void FillContour(int[,] mask, Contour contour, int width, int height)
        {
            Point insidePoint = Geometry.FindInsidePoint(contour);

            _insidePoint.Location = insidePoint;
            ShowInsidePoint();

            _maskGenerator.Mark(mask, insidePoint, mask[contour.Markers[0].CenterPosition.X, contour.Markers[0].CenterPosition.Y], width, height);
        }

        private Bitmap ExtractSectionsFromImage(Bitmap bitmap, int[,] contourMask)
        {
            Bitmap contourBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            int i, j;

            for (i = 0; i < bitmap.Width; i++)
            {
                for (j = 0; j < bitmap.Height; j++)
                {
                    if (contourMask[i, j] > 0)
                    {
                        contourBitmap.SetPixel(i, j, bitmap.GetPixel(i, j));
                    }
                    else
                    {
                        contourBitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }

            return contourBitmap;
        }
    }
}
