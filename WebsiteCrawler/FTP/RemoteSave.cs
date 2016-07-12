using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chilkat;

namespace WebsiteCrawler.FTP
{
    class RemoteSave
    {
            private static Ftp2 _ftp;
            private static bool Success { get; set; }


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

            public static bool FileExist(string fileName, State state)
            {
                Init();
                Success = _ftp.Connect();
                string file;
                try
                {
                    switch (state)
                    {
                        case State.TEMPLATE:
                            Success = _ftp.ChangeRemoteDir("Templates");
                            file = _ftp.GetRemoteFileTextData(fileName + ".xml");
                            break;
                        case State.ROUTE:
                            Success = _ftp.ChangeRemoteDir("Routes");
                            file = _ftp.GetRemoteFileTextData(fileName + ".csv");
                            break;
                        case State.INTERMEDIATE:
                            file = _ftp.GetRemoteFileTextData(fileName + ".csv");
                            break;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public enum State : int { TEMPLATE = 0, ROUTE = 1, INTERMEDIATE = 3, }
        

    }
}
