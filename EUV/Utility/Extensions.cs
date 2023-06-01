using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Utility
{
    public static class Extensions  // ListView 깜박임 제거
    {
        public static void DoubleBuffered(this Control control, bool enabled)
        {
            var prop = control.GetType().GetProperty(
                "DoubleBuffered",BindingFlags.Instance| BindingFlags.NonPublic);

            prop.SetValue(control, enabled, null);
        }
    }
}
