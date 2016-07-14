using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Chilkat;

namespace B2B_App.Models.APA.Configuration
{
    class RemoteSave
    {
        private static readonly StorageFolder Folder=ApplicationData.Current.LocalFolder;
        private static Ftp2 _ftp;
        public static bool Success { get; set; }


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
            FileListOnRemote=new List<string>();
        }

        public static async Task SaveContentToFtp(string content, string fileName, State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            
            switch (state)
            {
                case State.TEMPLATE:
                    Success = await _ftp.ChangeRemoteDirAsync("Templates");
                    Success = await _ftp.PutFileFromTextDataAsync(fileName+".xml", content, Encoding.UTF8.EncodingName);
                    break;
                case State.ROUTE:
                    Success = await _ftp.ChangeRemoteDirAsync("Routes");
                    Success = await _ftp.PutFileFromTextDataAsync(fileName+".csv", content, Encoding.UTF8.EncodingName);
                    break;
                    case State.INTERMEDIATE:
                    Success = await _ftp.PutFileFromTextDataAsync(fileName + ".csv", content, Encoding.UTF8.EncodingName);
                    break;
            }
            Success = await _ftp.DisconnectAsync();
        }

        public static async void SaveFileToFtp(string localFile, string fileName, State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            
            StorageFile file = await Folder.GetFileAsync(fileName);
            switch (state)
            {
                    case State.TEMPLATE:
                        Success = await _ftp.ChangeRemoteDirAsync("Templates");
                        Success = await _ftp.PutFileAsync(file.Path, fileName+".xml");
                        break;
                case State.ROUTE:
                    Success = await _ftp.ChangeRemoteDirAsync("Routes");
                    Success = await _ftp.PutFileAsync(file.Path, fileName+".csv");
                    break;
                    case State.INTERMEDIATE:
                    Success = await _ftp.PutFileAsync(file.Path, fileName + ".csv");
                    break;
            }
            Success = await _ftp.PutFileAsync(file.Path,fileName);
            Success = await _ftp.DisconnectAsync();
        }

        public static async Task<string> GetContentFromFtp(string fileName, State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            string data=null;
            switch (state)
            {
                case State.TEMPLATE:
                    Success = await _ftp.ChangeRemoteDirAsync("Templates");
                    data = await _ftp.GetRemoteFileTextDataAsync(fileName+".xml");
                    break;
                case State.ROUTE:
                    Success = await _ftp.ChangeRemoteDirAsync("Routes");
                    data = await _ftp.GetRemoteFileTextDataAsync(fileName+".csv");
                    break;
                    case State.INTERMEDIATE:
                    data = await _ftp.GetRemoteFileTextDataAsync(fileName + ".csv");
                    break;
            }
            Success = await _ftp.DisconnectAsync();
            return data;
        }

        public static async void GetFileFromFtp(string fileName, State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            string localPath = Folder.Path + "\\" + fileName;
            switch (state)
            {
                case State.TEMPLATE:
                    Success = await _ftp.ChangeRemoteDirAsync("Templates");
                    Success = await _ftp.GetFileAsync(localPath, fileName+".xml");
                    break;
                case State.ROUTE:
                    Success = await _ftp.ChangeRemoteDirAsync("Routes");
                    Success = await _ftp.GetFileAsync(localPath, fileName+".csv");
                    break;
                    case State.INTERMEDIATE:
                    Success = await _ftp.GetFileAsync(localPath, fileName + ".csv");
                    break;
            }
            Success = await _ftp.DisconnectAsync();
        }
        public async Task RemoveFileFromLocalDisk(string fileName)
        {
            StorageFile file = await Folder.GetFileAsync(fileName);
            await file.DeleteAsync();
        }

        public static async Task<bool> FileExist(string fileName, State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            string file;
            try
            {
                switch (state)
                {
                    case State.TEMPLATE:
                        Success = await _ftp.ChangeRemoteDirAsync("Templates");
                        file = await _ftp.GetRemoteFileTextDataAsync(fileName+".xml");
                        break;
                    case State.ROUTE:
                        Success = await _ftp.ChangeRemoteDirAsync("Routes");
                        file = await _ftp.GetRemoteFileTextDataAsync(fileName+".csv");
                        break;
                        case State.INTERMEDIATE:
                        file = await _ftp.GetRemoteFileTextDataAsync(fileName + ".csv");
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static List<string> FileListOnRemote;
        public static async Task<bool> GetFilesNames(State state)
        {
            Init();
            Success = await _ftp.ConnectAsync();
            try
            {
                int dir;
                switch (state)
                {
                    case State.TEMPLATE:
                        Success = await _ftp.ChangeRemoteDirAsync("Templates");
                        FileListOnRemote.Clear();
                        
                        dir = await _ftp.GetDirCountAsync();
                        for (int i = 0; i < dir; i++)
                        {
                            string fileName = await _ftp.GetFilenameAsync(i);
                            FileListOnRemote.Add(fileName);
                        }
                        break;
                    case State.ROUTE:
                        Success = await _ftp.ChangeRemoteDirAsync("Routes");
                        FileListOnRemote.Clear();
                        dir = await _ftp.GetDirCountAsync();
                        for (int i = 0; i < dir; i++)
                        {
                            string fileName = await _ftp.GetFilenameAsync(i);
                            FileListOnRemote.Add(fileName);
                        }
                        break;
                    case State.INTERMEDIATE:
                        FileListOnRemote.Clear();
                        dir = await _ftp.GetDirCountAsync();
                        for (int i = 0; i < dir; i++)
                        {
                            string fileName = await _ftp.GetFilenameAsync(i);
                            FileListOnRemote.Add(fileName);
                        }
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public enum State
        { TEMPLATE=0, ROUTE=1, INTERMEDIATE=3, }
    }
}
