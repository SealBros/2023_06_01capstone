using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Commons
{
    public static class Common
    {
        public static GMapMarker getMarker()
        {
            PointLatLng p = new PointLatLng(0, 0);
            float heading = 0;
            float cog = 0;
            float target = 0;
            int sysid = 0;

            //if drone
            var returnMarker = new GMapMarkerQuad(p, heading, cog, target, sysid);
            return returnMarker;
        }
    }

    
}
