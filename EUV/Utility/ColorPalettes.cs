using EUV.Commons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Utility
{
    public class ColorPalettes
    {
        private static Color c1 = Color.FromArgb(180, 4, 4);
        private static Color c2 = Color.FromArgb(180, 95, 4);
        private static Color c3 = Color.FromArgb(174, 180, 4);
        private static Color c4 = Color.FromArgb(4, 180, 4);
        private static Color c5 = Color.FromArgb(4, 180, 174);
        private static Color c6 = Color.FromArgb(4, 4, 180);
        private static Color c7 = Color.FromArgb(95, 4, 180);
        private static Color c8 = Color.FromArgb(180, 4, 174);
        private static Color c9 = Color.FromArgb(255, 0, 0);
        private static Color c10 = Color.FromArgb(255, 128, 0);
        private static Color c11 = Color.FromArgb(255, 255, 0);
        private static Color c12 = Color.FromArgb(0, 255, 0);
        private static Color c13= Color.FromArgb(0, 255, 255);
        private static Color c14 = Color.FromArgb(0, 0, 255);
        private static Color c15 = Color.FromArgb(128, 0, 255);
        private static Color c16 = Color.FromArgb(255, 0, 255);
        private static Color c17 = Color.FromArgb(245, 169, 169);
        private static Color c18 = Color.FromArgb(245, 208, 169);
        private static Color c19 = Color.FromArgb(242, 245, 169);
        private static Color c20 = Color.FromArgb(169, 245, 169);
        private static Color c21 = Color.FromArgb(169, 245, 242);
        private static Color c22 = Color.FromArgb(169, 169, 245);
        private static Color c23 = Color.FromArgb(208, 169, 245);
        private static Color c24 = Color.FromArgb(245, 169, 242);
        private static Color c25 = Color.FromArgb(255, 127, 80);
        private static Color c26 = Color.FromArgb(255, 165, 0);
        private static Color c27 = Color.FromArgb(255, 215, 0);
        private static Color c28 = Color.FromArgb(173, 255, 47);
        private static Color c29 = Color.FromArgb(135, 206, 250);
        private static Color c30 = Color.FromArgb(0, 191, 255);
        private static Color c31 = Color.FromArgb(139, 0, 139);
        private static Color c32 = Color.FromArgb(255, 105, 180);
        public Color C1 { get { return c1; } }
        public Color C2 { get { return c2; } }
        public Color C3 { get { return c3; } }
        public Color C4 { get { return c4; } }
        public Color C5 { get { return c5; } }
        public Color C6 { get { return c6; } }
        public Color C7 { get { return c7; } }
        public Color C8 { get { return c8; } }
        public Color C9 { get { return c9; } }
        public Color C10 { get { return c10; } }
        public Color C11 { get { return c11; } }
        public Color C12 { get { return c12; } }
        public Color C13 { get { return c13; } }
        public Color C14 { get { return c14; } }
        public Color C15 { get { return c15; } }
        public Color C16 { get { return c16; } }
        public Color C17 { get { return c17; } }
        public Color C18 { get { return c18; } }
        public Color C19 { get { return c19; } }
        public Color C20 { get { return c20; } }
        public Color C21 { get { return c21; } }
        public Color C22 { get { return c22; } }
        public Color C23 { get { return c23; } }
        public Color C24 { get { return c24; } }
        public Color C25 { get { return c25; } }
        public Color C26 { get { return c26; } }
        public Color C27 { get { return c27; } }
        public Color C28 { get { return c28; } }
        public Color C29 { get { return c29; } }
        public Color C30 { get { return c30; } }
        public Color C31 { get { return c31; } }
        public Color C32 { get { return c32; } }

        static List<Color> colors = new List<Color>() { 
            c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, 
            c11, c12, c13, c14, c15, c16, c17, c18, c19, c20,
            c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, 
            c31, c32 };

        public static void SetColor(Parameter parameter)
        {
            parameter.RouteColor = colors[parameter.ID-1];
        }
        public static Color GetColor(int i)
        {
            return colors[i-1];
        }
    }


}
