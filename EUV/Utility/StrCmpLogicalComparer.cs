using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Utility
{
    // 문자열 숫자 정렬
    public class StrCmpLogicalComparer : Comparer<string>
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string x, string y);

        public override int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
