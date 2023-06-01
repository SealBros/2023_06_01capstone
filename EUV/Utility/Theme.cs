using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Utility
{
    public class Theme
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly MetroStyleManager metroStyleManager;

        private static readonly Color DARK_COLOR = Color.FromArgb(55, 71, 79);
        private static readonly Color LIGHT_COLOR = Color.FromArgb(102, 187, 106);
        private static readonly Color DARK_BACK_COLOR = Color.FromArgb(51, 51, 51);
        private static readonly Color LIGHT_BACK_COLOR = Color.White;
        private static readonly Color DARK_TEXT_COLOR = Color.FromArgb(255, 110, 60);
        private static readonly Color LIGHT_TEXT_COLOR = Color.Black;
        private static readonly Color ENABLED_TEXT_COLOR = Color.Gray;


        private Commons.Properties prop = Commons.Properties.Instance();

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        private readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        public Color LightColor
        {
            get { return LIGHT_COLOR; }
        }
        public Color LightBackColor
        {
            get { return LIGHT_BACK_COLOR; }
        }
        public Color DarkColor
        {
            get { return DARK_COLOR; }
        }
        public Color DarkBackColor
        {
            get { return DARK_BACK_COLOR; }
        }
        public Color DarkTextColor
        {
            get { return DARK_TEXT_COLOR; }
        }
        public Color LightTextColor
        {
            get { return LIGHT_TEXT_COLOR; }
        }
        public Color EnabledTextColor
        {
            get { return ENABLED_TEXT_COLOR; }
        }

        Control[] control;

        public Control[] BackColorChangedControl
        {
            get { return control; }
            set { control = value; }
        }

        public FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }

        public Theme(MaterialForm form, IContainer container)
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);

            metroStyleManager = new MetroStyleManager(container);
            metroStyleManager.Owner = form;
        }

        public Theme(MaterialFormFlat form, IContainer container)
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);

            metroStyleManager = new MetroStyleManager(container);
            metroStyleManager.Owner = form;
        }
        private void ExitFullScreenBackColorChanged(Control control)
        {
            if (ThemeMode)
                control.BackColor = DarkBackColor;
            else
                control.BackColor = LightBackColor;
        }

        private void LogoBackColorChanged(Control control)
        {
            if (ThemeMode)
                control.BackColor = DarkColor;
            else
                control.BackColor = LightColor;
        }

        public bool ThemeMode
        {
            get { return prop.IsDarkTheme; }
            set
            {
                if (!value)
                {
                    prop.IsDarkTheme = false;
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green400, Primary.Green500, Primary.Green300, Accent.Orange400, TextShade.WHITE);
                    metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Light;
                    metroStyleManager.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else
                {
                    prop.IsDarkTheme = true;
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange200, TextShade.WHITE);
                    metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
                    metroStyleManager.Style = MetroFramework.MetroColorStyle.Orange;
                }
                if (control !=null&&control.Length == 1)
                {
                    LogoBackColorChanged(control[0]);
                    //ExitFullScreenBackColorChanged(control[1]);
                }
            }
        }
    }
}
