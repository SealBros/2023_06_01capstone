using GMap.NET;
using EUV.Utility;
using System;
using System.Drawing;

namespace EUV.Commons
{
    [Serializable]
    public class GMapMarkerBoat : GMapMarkerBase
    {
        private readonly Bitmap icon = global::EUV.Properties.Resources.boat_o0;

        float heading = 0;
        float cog = -1;
        float target = -1;
        float nav_bearing = -1;
        private int sysid = -1;

        public float warn = -1;
        public float danger = -1;

        static readonly Color green = Color.FromArgb(0x8d, 0xc6, 0x3f);
        static readonly Color blue = Color.FromArgb(0x00, 0xae, 0xef);
        static readonly Pen greenpen = new Pen(green, 3);
        static readonly Pen bluepen = new Pen(blue, 3);
        static readonly SolidBrush greenbrush = new SolidBrush(green);

        public float Heading { get => heading; set => heading = value; }
        public float Cog { get => cog; set => cog = value; }
        public float Target { get => target; set => target = value; }
        public int Sysid { get => sysid; set => sysid = value; }
        public float framerotation { get; set; } = 0;
        public float Nav_bearing { get; set; }
        public GMapMarkerBoat(PointLatLng p, float heading, float cog, float nav_bearing, float target, int sysid) : base(p)
        {
            {
                this.Heading = heading;
                this.Cog = cog;
                this.Target = target;
                this.Nav_bearing = nav_bearing;
                this.Sysid = sysid;
                Size = icon.Size;
                // for hitzone
                // Offset = new Point(-icon.Width / 1, -icon.Height / 1);
            }
        }

        public override void OnRender(Graphics g)
        {
            var temp = g.Transform;
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);

            g.RotateTransform(-Overlay.Control.Bearing);

            // anti NaN
            try
            {
                if (DisplayHeading)
                    g.DrawLine(new Pen(Color.Red, 2), 0.0f, 0.0f,
                        (float)Math.Cos((heading - 90) * Tools.deg2rad) * length,
                        (float)Math.Sin((heading - 90) * Tools.deg2rad) * length);
            }
            catch
            {
            }

            if (DisplayNavBearing)
                g.DrawLine(new Pen(Color.Green, 1), 0.0f, 0.0f,
                    (float)Math.Cos((nav_bearing - 90) * Tools.deg2rad) * length,
                    (float)Math.Sin((nav_bearing - 90) * Tools.deg2rad) * length);
            if (DisplayCOG)
                g.DrawLine(new Pen(Color.Black, 1), 0.0f, 0.0f,
                    (float)Math.Cos((cog - 90) * Tools.deg2rad) * length,
                    (float)Math.Sin((cog - 90) * Tools.deg2rad) * length);
            if (DisplayTarget)
                g.DrawLine(new Pen(Color.Orange, 1), 0.0f, 0.0f,
                    (float)Math.Cos((target - 90) * Tools.deg2rad) * length,
                    (float)Math.Sin((target - 90) * Tools.deg2rad) * length);
            // anti NaN

            //id
            //g.DrawString(Sysid.ToString(), new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, -16, 32);
           
            try
            {
                g.RotateTransform(heading);
            }
            catch
            {
            }


            /*Rectangle rec = new Rectangle(-10, 0, 20, 20);
            Brush brush = new SolidBrush(ColorPalettes.SetColor(this.sysid));
            g.FillEllipse(brush, rec);

            g.DrawImageUnscaled(global::EUV.Properties.Resources.boat_o0,
                Size.Width / -2,
                Size.Height / -2);*/


            Pen _pen = new Pen(Color.Blue/*ColorPalettes.GetColor(Sysid)*/);
            Point[] _point01 = new Point[]
            {
                new Point(0,0),new Point(-10,35),new Point(10,35)
            };

            g.DrawPolygon(_pen, _point01);
            SolidBrush _brush = new SolidBrush(Color.Blue/*ColorPalettes.GetColor(Sysid)*/);
            Point[] _point02 = new Point[]
            {
                new Point(0,0),new Point(-10,35),new Point(10,35)
            };
            g.FillPolygon(_brush, _point02);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(Sysid.ToString(), new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold), Brushes.Red, 0, 45, sf);

            g.Transform = temp;
        }
    }
}
