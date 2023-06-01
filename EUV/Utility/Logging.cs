using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EUV.Utility
{
    class Logging
    {
        private static string logPath = "C:\\SKYSYS\\LOG";
        private string logFile = Path.Combine(logPath, "Debuglog_" + DateTime.Now.Date.ToString("yyMMdd") + ".txt");
        private static Logging instance;

        bool logStart = false;
        public static Logging Instance()
        {
            if (instance == null)
            { instance = new Logging(); }

            return instance;
        }
        /// <summary>
        /// 프로그램  --  시간과 로그 메시지 기록
        /// </summary>
        /// <param name="log"></param>
        ///
        public void DebugLog(string log)
        {
            createDirectory();

            if (File.Exists(logFile))
            {
                StringBuilder sb = new StringBuilder();
                if (logStart)
                {
                    sb.AppendLine("GCS Program log file");
                    sb.AppendLine($"Date: {DateTime.Now.ToString("D")}");
                    sb.AppendLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                    logStart = false;
                }

                sb.AppendLine("## " + DateTime.Now.ToString("HH:mm:ss.fff") + "\t" + log + "\t");   //로그

                try
                {
                    string FormID = "UNKNOWN";
                    StackTrace st = new StackTrace(true);
                    for (int i = 1; i < st.FrameCount; i++)
                    {
                        MethodBase method = st.GetFrame(i).GetMethod();
                        if (typeof(Form).IsAssignableFrom(method.DeclaringType) || typeof(Control).IsAssignableFrom(method.DeclaringType) || typeof(Object).IsAssignableFrom(method.DeclaringType))
                        {
                            FormID = method.DeclaringType.Name + "." + method.Name;
                            break;
                        }
                    }

                    sb.Insert(sb.Length - 2, FormID);   //에러 발생 위치

                    File.AppendAllText(logFile, sb.ToString());
                }
                catch
                { }

            }
        }

        public void MessageLog(string log)
        {
            createDirectory();

            if (File.Exists(logFile))
            {
                StringBuilder sb = new StringBuilder();
                if (logStart)
                {
                    sb.AppendLine("GCS Program log file");
                    sb.AppendLine($"Date: {DateTime.Now.ToString("D")}");
                    sb.AppendLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                    logStart = false;
                }

                sb.AppendLine("## " + DateTime.Now.ToString("HH:mm:ss.fff") + "\t" + log + "\t");   //로그

                try
                {
                    string FormID = "UNKNOWN";
                    StackTrace st = new StackTrace(true);
                    for (int i = 1; i < st.FrameCount; i++)
                    {
                        MethodBase method = st.GetFrame(i).GetMethod();
                        if (typeof(Form).IsAssignableFrom(method.DeclaringType) || typeof(Control).IsAssignableFrom(method.DeclaringType) || typeof(Object).IsAssignableFrom(method.DeclaringType))
                        {
                            FormID = method.DeclaringType.Name + "." + method.Name;
                            break;
                        }
                    }

                    sb.Insert(sb.Length - 2, FormID);   //에러 발생 위치
                }
                catch
                { }

                File.AppendAllText(logFile, sb.ToString());
            }
        }

        // 폴더 생성
        public void createDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(logPath);

            if (!di.Exists)
            {
                di.Create();
            }

            createFile(logFile);
        }

        public void createFile(string path)
        {
            FileInfo fi = new FileInfo(path);

            if (!fi.Exists)
            {
                using (fi.Create())
                    logStart = true;
            }
        }

        /// <summary>
        /// 콘솔 출력
        /// </summary>
        /// <param name="log"></param>
        public void DebugConsole(string log)
        {
            Console.WriteLine(log);
        }

        /// <summary>
        /// 로그 기록 여부를 확인
        /// </summary>
        /// <param name="log"></param>
        public void isDebug(string log)
        {
            if (Commons.Properties.Instance().IsProgramLog)
            {
                DebugLog(log);
            }
            else
            {
                DebugConsole(log);
            }
        }

    }


}
