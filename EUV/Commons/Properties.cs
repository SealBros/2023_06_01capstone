namespace EUV.Commons
{
    /// <summary>
    /// 프로그램 관련 속성
    /// </summary>
    class Properties
    {
        private static Properties instance;
        public static Properties Instance()
        {
            if (instance == null)
            {
                instance = new Properties();
            }

            return instance;
        }


        /// <summary>
        /// 생성자
        /// </summary>
        public Properties()
        {
            loadProperties();
        }

        #region GMAP
        public string MAPPROVIDER { get; set; }
        public int MaxZoom { get; set; }
        public int MinZoom { get; set; }
        public int Zoom { get; set; }
        #endregion GMAP

        #region Program
        public bool IsProgramLog { get; set; }

        public bool IsDarkTheme { get; set; }

        #endregion

        /// <summary>
        /// 초기값 읽어오기
        /// File : setting.ini
        /// </summary>
        public void loadProperties()
        {
            //string iniPath = Application.StartupPath + @"\setting.ini";
            string iniPath = "C:\\SKYSYS\\EUV_Setting.ini";

            Utility.INIFileHandle filehandle = new Utility.INIFileHandle(iniPath);

            bool getBooleanValue;
            int getIntValue;

            #region GMap
            MAPPROVIDER = filehandle.IniReadValue("MAP", "MAPPROVIDER", "");
            if (int.TryParse(filehandle.IniReadValue("MAP", "MAX_ZOOM", ""), out getIntValue))
            { MaxZoom = getIntValue; }
            if (int.TryParse(filehandle.IniReadValue("MAP", "MIN_ZOOM", ""), out getIntValue))
            { MinZoom = getIntValue; }
            if (int.TryParse(filehandle.IniReadValue("MAP", "ZOOM", ""), out getIntValue))
            { Zoom = getIntValue; }
            #endregion GMAP

            #region Program
            if (bool.TryParse(filehandle.IniReadValue("PROGRAM", "PROGRAM_LOG", ""), out getBooleanValue))
            { IsProgramLog = getBooleanValue; }
            if (bool.TryParse(filehandle.IniReadValue("PROGRAM", "DARK_THEME", ""), out getBooleanValue))
            { IsDarkTheme = getBooleanValue; }
            #endregion
        }

        public void saveProperties(string section, string key, string value)
        {
            string iniPath = "C:\\SKYSYS\\EUV_Setting.ini";
            //string inipath2 = Application.StartupPath + @"\setting.ini";
            Utility.INIFileHandle filehandle = new Utility.INIFileHandle(iniPath);

            filehandle.IniWriteValue(section, key, value);
        }
    }
}
