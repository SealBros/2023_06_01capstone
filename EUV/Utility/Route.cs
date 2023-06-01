using GMap.NET;
using GMap.NET.WindowsForms;
using System.Collections.Generic;
using System.Drawing;

namespace EUV.Utility
{
    public class Route
    {
        public string FullName { get; set; }
        public string FileName { get; set; }
        public List<Point> Points { get; set; }

        public Route()
        {
        }

        public Route(string fullName, List<Point> listPoints)
        {
            FullName = fullName;
            FileName = fullName.Substring(fullName.LastIndexOf(@"\") + 1);
            Points = listPoints;
        }

    }
}
