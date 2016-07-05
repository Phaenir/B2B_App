using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.Networking;
using Windows.Networking.Sockets;
using FTP_Client;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateConfigModel
    {
        public async void SaveInFtp()
        {
            Uri uri=new Uri("ftp://lokador.net");
            NetworkCredential network=new NetworkCredential("b2bapp", "3P3k6P8t");
            FtpClient client =new FtpClient(host: uri, credential:network);
            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                throw new Exception("Connection is not able to set to FTP: Lokador.net");
            }
            if (client.IsConnected)
            {
                Debug.Assert(true,"is OK with ftp Connection");
            }
        }
    }
}
