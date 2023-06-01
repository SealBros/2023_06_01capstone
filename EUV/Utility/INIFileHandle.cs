using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace EUV.Utility
{
    class INIFileHandle
    {
        #region INI FILE section control
        #region [선언] dll 선언

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);
        public FileInfo cFileInfo = null;
        private string path;


        #endregion

        #region 생성자
        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public INIFileHandle(string INIPath)
        {
            path = INIPath;
            cFileInfo = new FileInfo(path);

            if (!cFileInfo.Exists) FileCreate();
        }
        ~INIFileHandle()
        {
            cFileInfo = null;
        }

        #endregion


        #region [Method] IniWriteValue
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            long aa;
            aa = WritePrivateProfileString(Section, Key, Value, this.path);

            long bb = aa;
        }

        #endregion

        #region [Method] IniReadValue
        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            return IniReadValue(Section, Key, "");
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        public string IniReadValue(string Section, string Key, string Defalut)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);


                if (temp.ToString() == "")
                    return Defalut;
                else
                    return temp.ToString();
            }
            catch (Exception ex)
            {
                //string aa = ex.Message;
                //Error.SystemError(this.ToString(), ex); 
                Logging.Instance().DebugConsole(ex.ToString());
                return Defalut;
            }
        }
        #endregion
        #endregion

        #region File Info (createFile/ deleteFile/ write FIle/ readFile)
        //<System.IO provides >
        //Binary                            Reader and Writer Read and write primitive data types 
        //Directory, File, DirectoryInfo, and FileInfo Create, delete, and move files and directories. 
        //                                  Get specific information about the files by making use of the properties defined in these classes. 
        //FileStream Access                 the files in a random fashion 
        //MemoryStream                      Access data stored in memory 
        //StreamWriter and StreamReader     Read and write textual information 
        //StringReader and StringWriter     Read and write textual Information from a string buffer 

        //<Working  with DirectoryInfo and FileInfo classes>
        //Attributes        Returns     attributes associated with a file. Takes FileAttributes enumeration values 
        //CreationTime      Returns     the time of creation of the file 
        //Exists            Checks      whether a supplied file is a directory or not 
        //Extension         Returns     the file extension 
        //LastAccessTime    Returns     last accessed time of the file 
        //FullName          Returns     the full path of the file 
        //LastWriteTime     Returns     the time of last written activity to the file 
        //Name              Returns     the name of a given file 
        //Delete()          Deletes     a file. Be careful when using this method. 

        //<Archive Returns the file's Archive status >
        //Compressed        Returns     whether the file is compressed or not 
        //Directory         Returns     whether the file is a directory or not 
        //Encrypted         Returns     whether the file is encrypted or not 
        //Hidden            Returns     whether the file is hidden or not 
        //Offline           Signifies   that the data is not available 
        //ReadOnly          Indicates   that the file is read only 
        //System            Indicates   that the file is a System file (probably a file under the Windows folder) 



        #region [Method] CreateFile
        /// <summary>
        /// File Create
        /// </summary>
        public bool FileCreate()
        {
        reFileCreate:
            bool bCreateFile = false;
            if (!cFileInfo.Exists)
            {
                try
                {

                    FileStream fstr = cFileInfo.Create();
                    fstr.Close();
                }
                catch (DirectoryNotFoundException)
                {
                    if (CreatePath(cFileInfo.DirectoryName))
                    {
                        goto reFileCreate;
                    }

                }
                catch (Exception ex)
                {
                    //Error.SystemError(this.ToString(), ex);
                    Utility.Logging.Instance().DebugConsole(ex.ToString());

                }
            }
            return bCreateFile;
        }
        #endregion

        /// <summary>
        /// Directory path return string[]
        /// </summary>
        /// <remarks>디렉토리 생성시 path를 string[]리턴한다</remarks>
        /// <returns>string[]</returns>
        private ArrayList GetPathDirectory(string FullPathDirectory)
        {
            int start = 4;

            ArrayList path = new ArrayList();


            if (FullPathDirectory != null)
            {
                while (start < FullPathDirectory.Length)
                {
                    start = FullPathDirectory.IndexOf('\\', start) + 2;

                    try
                    {
                        path.Add(FullPathDirectory.Substring(0, start - 2));
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        path.Add(FullPathDirectory);
                        return path;
                    }
                }
            }
            return path;
            //throw new System.NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Directory Create
        /// </summary>
        /// <param name="FullPathDirectory">CreateFullpath</param>
        /// <returns>bool</returns>
        public bool CreatePath(string FullPathDirectory)
        {
            ArrayList strFullPath = GetPathDirectory(FullPathDirectory);
            //throw new System.NotImplementedException();
            bool bCreatePath = false;
            foreach (string path in strFullPath)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    bCreatePath = true;
                }
            }
            return bCreatePath;
        }
    }
}
