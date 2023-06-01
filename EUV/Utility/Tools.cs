using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Utility
{
    public static class Tools
    {
        #region 인스턴스 선언 및 반환
        //private static Tools _instance;

        //public static Tools _getInstance()
        //{
        //    if (_instance == null)
        //        _instance = new Tools();

        //    return _instance;
        //}
        #endregion

        #region MathHelper
        public const double rad2deg = (180 / Math.PI);
        public const double deg2rad = (1.0 / rad2deg);
        #endregion

        #region 로그 기록
        public static void _debugLog(string _durationLog)
        {
            string _logFile = Path.Combine(Application.StartupPath, "DB_LOG");
            _logFile = Path.Combine(_logFile, "debug_log.txt");

            if (File.Exists(_logFile))
            {
                StringBuilder _sb = new StringBuilder();


                _sb.AppendLine("--------------------------------------------------");

                try
                {
                    string _formID = "UNKNOWN";
                    StackTrace _st = new StackTrace(true);
                    for (int i = 1; i < _st.FrameCount; i++)
                    {
                        MethodBase _method = _st.GetFrame(i).GetMethod();
                        if (typeof(Form).IsAssignableFrom(_method.DeclaringType) || typeof(Control).IsAssignableFrom(_method.DeclaringType) || typeof(Object).IsAssignableFrom(_method.DeclaringType))
                        {
                            _formID = _method.DeclaringType.Name + "." + _method.Name;
                            break;
                        }
                    }
                    _sb.Insert(0, "--" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff) (") + _durationLog + ")\r\n");
                    _sb.Insert(0, "--" + _formID + "\r\n");
                    File.AppendAllText(_logFile, _sb.ToString());
                }
                catch
                {
                }
            }
        }
        #endregion

        #region 콘솔 출력
        public static void _writeLine(string _msg)
        {
            if (Properties.Settings.Default._boolDebugging)
            {
                Console.WriteLine(_msg);
            }
        }
        #endregion

        #region HEX to ASCII
        public static string hexToAsciiSMS(string hexString)
        {
            Byte[] _byteA = new byte[hexString.Length / 2];
            int p = 0;
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                int hex = Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                _byteA[p] = (byte)hex;
                p++;
            }
            string _charArray = "";
            for (int j = 0; j < _byteA.Length; j++)
            {
                if (_byteA[j] > 127)//한글 2바이트 시점(128부터)
                {
                    _charArray += Encoding.GetEncoding(949).GetString(_byteA, j, 2);
                    j++;
                }
                else
                {
                    _charArray += Encoding.GetEncoding(949).GetString(_byteA, j, 1);
                }
            }
            return _charArray;   //hex값을 아스키(한글/영문)로
        }

        /// <summary>
        /// SMS 전체 메시지중 본문을 아스키 문자로 변경
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static string hexToAscii(string hexString)//분해전 전체 (전화번호 등 포함 메시지)
        {
            string[] hexstrings = hexString.Split(',');

            Byte[] _byteA = new byte[hexstrings[5].Length / 2];
            int p = 0;
            for (int i = 0; i <= hexstrings[5].Length - 2; i += 2)
            {
                int hex = Int32.Parse(hexstrings[5].Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                _byteA[p] = (byte)hex;
                p++;

            }
            string _charArray = "";
            for (int j = 0; j < _byteA.Length; j++)
            {
                if (_byteA[j] > 127)//한글 2바이트 시점(128부터)
                {
                    _charArray += Encoding.GetEncoding(949).GetString(_byteA, j, 2);
                    j++;
                }
                else
                {
                    _charArray += Encoding.GetEncoding(949).GetString(_byteA, j, 1);
                }
            }
            return _charArray;   //hex값을 아스키(한글/영문)로
        }
        #endregion
    }
}
