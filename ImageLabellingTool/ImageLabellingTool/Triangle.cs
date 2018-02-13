using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLabellingTool
{
    public class Triangle: Contour
    {
        public Triangle()
        {
            ContourType = this.GetType();
        }

        public void DrawLines(Graphics e)
        {
            for (int i = 0; i < Markers.Count - 1; i++)
            {
                e.DrawLine(Pen, Markers[i].CenterPosition, Markers[i + 1].CenterPosition);
            }

            if (ContourReady)
            {
                e.DrawLine(Pen, Markers[0].CenterPosition, Markers[Markers.Count - 1].CenterPosition);
            }
        }
    }
}
