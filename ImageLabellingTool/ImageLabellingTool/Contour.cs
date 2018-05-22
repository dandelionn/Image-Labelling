using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageLabellingTool
{
    public abstract class Contour
    {
        public Type ContourType;
        public List<Marker> Markers {get; set;}
        public Pen Pen {get; set;}
        protected bool ContourReady {get; set;}

        public Contour()
        {
            Markers = new List<Marker>();
            Pen = new Pen(Color.Blue);
            ContourReady = false;
        }

        public bool AddMarker(Marker marker)
        {
            Markers.Add(marker);

            if (Markers.Count > 2 && Markers[0].Bounds.IntersectsWith(Markers[Markers.Count - 1].Bounds))
            {
                ContourReady = true;
                Markers.RemoveAt(Markers.Count - 1);

                return true;
            }

            return false;
        }
    }
}
