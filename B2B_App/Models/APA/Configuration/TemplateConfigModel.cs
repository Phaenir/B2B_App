using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Automation.Peers;
using Chilkat;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateConfigModel
    {
        string path;
        

        public async Task<Template> GetConfiguration(string fileName)
        {
            Template template = new Template();
            WebsiteTemplate website;
            string xml = await RemoteSave.GetContentFromFtp(fileName, RemoteSave.State.TEMPLATE);
            website = WebsiteTemplate.Deserialize(xml);
            
            config.AgencyName = configuration.BerlogicEngine.Agency.Name;
            config.AgencyNumber = configuration.BerlogicEngine.Agency.Number;
            config.AgencyPassword = configuration.BerlogicEngine.Agency.Password;
            config.AgencySalespoint = configuration.BerlogicEngine.Agency.Salespoint;
            config.DatabaseHost = configuration.Database.Host;
            config.DatabaseName = configuration.Database.Name;
            config.DatabasePassword = configuration.Database.Password;
            config.DatabasePort = configuration.Database.Port;
            config.DatabaseRemote = configuration.Database.RemoteHost;
            config.DatabaseUser = configuration.Database.User;
            config.FormLimit = configuration.SearchEngine.FormLimit;
            config.PageLimit = configuration.SearchEngine.PageLimit;
            config.SearchLimit = configuration.SearchEngine.SearchLimit;

            return config;
        }

        public void SetConfiguration(Template website)
        {
            //var configuration = CommonConfiguration.LoadFromFile(PathToCommonConfigFile.NAME,PathToCommonConfigFile.FOLDER).Result;
            CommonConfiguration configuration = CommonConfiguration.LoadFromFile(path);
            configuration.StateDate = DateTime.Now;
            configuration.BerlogicEngine.Agency.Name = config.AgencyName;
            configuration.BerlogicEngine.Agency.Number = config.AgencyNumber;
            configuration.BerlogicEngine.Agency.Password = config.AgencyPassword;
            configuration.BerlogicEngine.Agency.Salespoint = config.AgencySalespoint;
            configuration.Database.Host = config.DatabaseHost;
            configuration.Database.Name = config.DatabaseName;
            configuration.Database.Password = config.DatabasePassword;
            configuration.Database.Port = config.DatabasePort;
            configuration.Database.RemoteHost = config.DatabaseRemote;
            configuration.Database.User = config.DatabaseUser;
            configuration.SearchEngine.FormLimit = config.FormLimit;
            configuration.SearchEngine.PageLimit = config.PageLimit;
            configuration.SearchEngine.SearchLimit = config.SearchLimit;
            configuration.Serialize();
            configuration.SaveToFile(PathToCommonConfigFile.NAME, PathToCommonConfigFile.FOLDER);
            //string path = @"D:\Common Documents\visual studio 2015\Projects\B2B_App\B2B_App\bin\x86\Debug\AppX\ConfigFiles\" + ConfigFileName;
            //CommonConfiguration.SaveToFile(path,configuration,true);
        }

        private async Task<bool> FileExist(string name)
        {
          return  await RemoteSave.FileExist(name + ".xml", RemoteSave.State.TEMPLATE);
        }
    }
}