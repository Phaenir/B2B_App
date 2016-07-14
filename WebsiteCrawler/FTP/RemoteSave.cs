using System;
using System.Diagnostics;
using Chilkat;

namespace WebsiteCrawler.FTP
{
    /// <summary>
    /// Class to manage data in remote server using ftp
    /// </summary>
    static class RemoteSave
    {
        /// <summary>
        /// define ftp
        /// </summary>
            private static Ftp2 _ftp;
        /// <summary>
        /// the flag that show result of process
        /// </summary>
            private static bool Success { get; set; }
        /// <summary>
        /// initialize parameters for ftp connection
        /// </summary>
            private static void Init()
            {
                _ftp = new Ftp2();
                Success = _ftp.UnlockComponent("Anything for 30-day trial");
                if (!Success)
                {
                    Debug.Assert(false, _ftp.LastErrorText);
                }
                _ftp.Hostname = "ftp.lokador.net";
                _ftp.Username = "b2bapp";
                _ftp.Password = "3P3k6P8t";
                _ftp.Port = 21;
                _ftp.Passive = false;
            }

        /// <summary>
        /// take content from remote server
        /// </summary>
        /// <param name="fileName">the name of file</param>
        /// <param name="state">state that defines in which folder this file exist</param>
        /// <returns></returns>
            public static string GetContentFromFtp(string fileName, State state)
            {
                Init();
                Success = _ftp.Connect();
                string data = null;
                switch (state)
                {
                    case State.TEMPLATE:
                        Success = _ftp.ChangeRemoteDir("Templates");
                        data = _ftp.GetRemoteFileTextData(fileName + ".xml");
                        break;
                    case State.ROUTE:
                        Success = _ftp.ChangeRemoteDir("Routes");
                        data = _ftp.GetRemoteFileTextData(fileName + ".csv");
                        break;
                    case State.INTERMEDIATE:
                        data = _ftp.GetRemoteFileTextData(fileName + ".csv");
                        break;
                }
                Success = _ftp.Disconnect();
                return data;
            }
        /// <summary>
        /// download files from remote server using ftp 
        /// </summary>
        /// <param name="path">path in local machine where need save file</param>
        /// <param name="fileName">name of the file that need to download</param>
        /// <param name="state">state that defines in which folder this file exist</param>
        public static void GetFileFromFtp(string path,string fileName, State state)
            {
                Init();
                Success = _ftp.Connect();
                string localPath = path + "\\" + fileName;
                switch (state)
                {
                    case State.TEMPLATE:
                        Success = _ftp.ChangeRemoteDir("Templates");
                        Success = _ftp.GetFile(localPath, fileName + ".xml");
                        break;
                    case State.ROUTE:
                        Success = _ftp.ChangeRemoteDir("Routes");
                        Success = _ftp.GetFile(localPath, fileName + ".csv");
                        break;
                    case State.INTERMEDIATE:
                        Success = _ftp.GetFile(localPath, fileName + ".csv");
                        break;
                }
                Success = _ftp.Disconnect();
            }
        
            public enum State
            { TEMPLATE = 0, ROUTE = 1, INTERMEDIATE = 3, }       
    }
}
