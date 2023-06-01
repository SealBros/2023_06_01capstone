using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Commons
{
    class Envi
    {
        #region 소켓 변수
        public static readonly string _IPAddress = "192.168.117.106";//"192.168.88.26";//"10.8.0.10";//"192.168.255.253";//"192.168.88.42";   //"192.168.0.6";
        public static readonly int _SocketPort = 9000;
        #endregion

        #region 스레드 변수(프로그램 구동시만)
        public static readonly bool _socketThreadInitRunning = true;
        #endregion

        #region 프로그램 환경 로드
        internal static void _loadEnvironment()
        {
            /*
            try
            {
                DataTable _dt;
                if (Envi._dbType == 1)
                { _dt = StoredProcedureCall.GlobalSelect("select * from envi"); }
                else if (Envi._dbType == 2)
                { _dt = StoredProcedureCall.MySqlGlobalSelect("select * from envi"); }
                else //if (Envi._dbType == 3)
                { _dt = StoredProcedureCall.OracleGlobalSelect("select * from envi"); }
                foreach (DataRow _dr in _dt.Rows)
                {
                    string _CODE = _dr["CODE"].ToString();// GUIHelpers.ConvertToString(row, "CODE");
                    string _VALUE = _dr["CNAME"].ToString();// GUIHelpers.ConvertToString(row, "CD_NM");
                    if (string.IsNullOrWhiteSpace(_CODE)) continue;

                    FieldInfo _info = typeof(Envi).GetField(_CODE, BindingFlags.Static | BindingFlags.Public);
                    if (_info == null) continue;

                    if (_info.FieldType == typeof(string))
                        _info.SetValue(null, _VALUE);
                    else if (_info.FieldType == typeof(int))
                        _info.SetValue(null, Convert.IsDBNull(_VALUE) ? 0 : Convert.ToInt32(_VALUE));
                    else if (_info.FieldType == typeof(long))
                        _info.SetValue(null, Convert.IsDBNull(_VALUE) ? 0 : Convert.ToInt64(_VALUE));
                    else if (_info.FieldType == typeof(decimal))
                        _info.SetValue(null, Convert.IsDBNull(_VALUE) ? 0 : Convert.ToDecimal(_VALUE));
                    else if (_info.FieldType == typeof(bool))
                        _info.SetValue(null, Convert.IsDBNull(_VALUE) ? false : Convert.ToBoolean(_VALUE));
                    else if (_info.FieldType == typeof(DateTime))
                        _info.SetValue(null, Convert.IsDBNull(_VALUE) ? DateTime.MinValue : Convert.ToDateTime(_VALUE));
                    else if (_info.FieldType == typeof(Size))
                        _info.SetValue(null, string.IsNullOrWhiteSpace(_VALUE) ? Size.Empty : new Size(Convert.ToInt32(_VALUE.Split(',')[0]), Convert.ToInt32(_VALUE.Split(',')[1])));
                }
            }
            catch (Exception _ex)
            {
                Utilities.Tools._writeLine(_ex.ToString());
                //Application.Exit();
            }
            */
        }

        #endregion
    }
}
