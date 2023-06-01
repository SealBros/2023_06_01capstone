using System.Collections.Generic;
using System.Drawing;

namespace EUV.Views
{
    public class PointArrayEqualityComparer : IEqualityComparer<Point[]>
    {
        public bool Equals(Point[] x, Point[] y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null || x.Length != y.Length)
                return false;

            for (int i = 0; i < x.Length; i++)
            {
                if (!x[i].Equals(y[i]))
                    return false;
            }

            return true;
        }

        public int GetHashCode(Point[] obj)
        {
            if (obj == null)
                return 0;

            int hash = 17;
            foreach (var point in obj)
            {
                hash = hash * 23 + point.GetHashCode();
            }
            return hash;
        }
    }

}