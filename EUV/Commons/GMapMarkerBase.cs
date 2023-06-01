using System;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace EUV.Commons
{
    [Serializable]
    public class GMapMarkerBase : GMapMarker
    {
        public static bool DisplayCOG = false;
        public static bool DisplayHeading = true;
        public static bool DisplayNavBearing = false;
        public static bool DisplayRadius = false;
        public static bool DisplayTarget = false;
        public static int length = 30;

        public GMapMarkerBase(PointLatLng pos) : base(pos)
        {
        }
    }
}
