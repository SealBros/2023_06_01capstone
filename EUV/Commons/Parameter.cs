using EUV.Utility;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EUV.Commons
{
    public class Parameter
    {
        private int id;
        private string mode;
        private bool isArm=true;
        private bool isAlive = false;
        #region < from - 경로 >
        private string routeFileName = "-";
        private List<Point> points = new List<Point>();
        private List<PointLatLng> pointGps = new List<PointLatLng>();
        private PointLatLng currentGps = new PointLatLng(0,0);
        private GMapMarkerBoat boatMarker = null;
        private Color routeColor = Color.Transparent;
        #endregion < to - 경로 >

        public Parameter(int id)
        {
            this.id = id;
            ColorPalettes.SetColor(this);
        }

        public Parameter(int id, string mode)
        {
            this.id = id;
            this.mode = mode;
            ColorPalettes.SetColor(this);
        }
        /// <summary>
        /// 선박 ID
        /// </summary>
        public int ID { get { return id; } set { id = value; } }
        /// <summary>
        /// 선박 운행 모드
        /// </summary>
        public string Mode { get { return mode; } set { mode = value; } }
        /// <summary>
        /// 선박 시동
        /// </summary>
        public bool IsArm { get { return isArm; } set { isArm = value; } }
        /// <summary>
        /// 선박의 연결 여부
        /// </summary>
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        #region < from - 경로 > 
        /// <summary>
        /// 선박의 경로 파일 이름
        /// </summary>
        public string RouteFileName { get { return routeFileName; } set { routeFileName = value; } }
        /// <summary>
        /// 선박의 경로 주행 좌표 
        /// </summary>
        public List<Point> Points { get { return points; } set { points = value; } }
        /// <summary>
        /// 선박의 경로 주행 위치 
        /// </summary>
        public List<PointLatLng> PointGps { get { return pointGps; } set { pointGps = value; } }
        /// <summary>
        /// 선박의 현재 위치
        /// </summary>
        public PointLatLng CurrentGps { get { return currentGps; }set { currentGps = value; } }
        /// <summary>
        /// 선박 마커
        /// </summary>
        public GMapMarkerBoat BoatMarker { get { return boatMarker; } set { boatMarker = value; } }
        /// <summary>
        /// 선박의 경로 출력 색
        /// </summary>
        public Color RouteColor { get { return routeColor; } set { routeColor = value; } }
        #endregion < to - 경로 >

        public void pointToGps(PointLatLng centerGps, int heading)
        {
            PointGps.Clear();
            //return FileName;
            foreach (var point in points)
            {
                PointLatLng p = getLocationMetres(centerGps, point.Y / 100.0, point.X / 100.0, heading);

                pointGps.Add(p);
                //Console.WriteLine(string.Format("X : {0}, Z : {1}", point.X, point.Y));
            }
        }

        private PointLatLng getLocationMetres(PointLatLng original_location, double dNorth, double dEast, int dHeading = 0)
        {
            var h = -dHeading;
            var dy = dEast * Math.Sin(h * Math.PI / 180) + dNorth * Math.Cos(h * Math.PI / 180);
            var dx = dEast * Math.Cos(h * Math.PI / 180) - dNorth * Math.Sin(h * Math.PI / 180);

            var earth_radius = 6378137.0;
            var dLat = dy / earth_radius;
            var dLng = dx / (earth_radius * Math.Cos(Math.PI * original_location.Lat / 180));

            var newLat = original_location.Lat + (dLat * 180 / Math.PI);
            var newLng = original_location.Lng + (dLng * 180 / Math.PI);
            return new PointLatLng(newLat, newLng);
        }
    }
}
