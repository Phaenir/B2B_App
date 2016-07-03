using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;

namespace B2B_App.Models.APA.Configuration
{
    class CommonConfigurationModel
    {
        private readonly string ConfigFileName = "ConfigFile.xml";
        private readonly string CommonConfigFolder = "ConfigFiles";
        //private CommonConfiguration configuration;
        string path;
        private void Init(out CommonConfiguration common)
        {
            common=new CommonConfiguration();
            CommonConfigurationBerlogicEngineAgency agency = new CommonConfigurationBerlogicEngineAgency
            {
                Name = "Test",
                Number = "0123",
                Password = "0123",
                Salespoint = "Test"
            };
            CommonConfigurationDatabase database = new CommonConfigurationDatabase
            {
                Name = "testdb",
                Host = "127.0.0.1",
                Password = "test",
                Port = 3306,
                RemoteHost = "255.255.255.255",
                User = "test"
            };
            CommonConfigurationSearchEngine searchEngine = new CommonConfigurationSearchEngine
            {
                FormLimit = 2,
                PageLimit = 1,
                SearchLimit = 2
            };

            common.BerlogicEngine.Agency = agency;
            common.Database = database;
            common.SearchEngine = searchEngine;
            common.StateDate=DateTime.Now;

            common.Serialize();
            common.SaveToFile(PathToCommonConfigFile.NAME,PathToCommonConfigFile.FOLDER);   
        }

        public async void WaitConfig()
        {
            CommonConfiguration configuration = await CommonConfiguration.LoadFromFile(PathToCommonConfigFile.NAME, PathToCommonConfigFile.FOLDER);
            await Task.CompletedTask;
        }
        public CommonConfig GetConfiguration()
        {
            CommonConfig config=new CommonConfig();
            CommonConfiguration configuration;
            if (!FileExist())
            {
                Init(out configuration);
            }
            else
            {
                configuration = CommonConfiguration.LoadFromFile(path);
            }
            //string path= @"D:\Common Documents\visual studio 2015\Projects\B2B_App\B2B_App\bin\x86\Debug\AppX\ConfigFiles\"+ConfigFileName;
            //configuration=CommonConfiguration.LoadFromFile(PathToCommonConfigFile.NAME,PathToCommonConfigFile.FOLDER).Result;
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

        public void SetConfiguration(CommonConfig config)
        {
            //var configuration = CommonConfiguration.LoadFromFile(PathToCommonConfigFile.NAME,PathToCommonConfigFile.FOLDER).Result;
            CommonConfiguration configuration = CommonConfiguration.LoadFromFile(path);
            configuration.StateDate=DateTime.Now;
            configuration.BerlogicEngine.Agency.Name = config.AgencyName;
            configuration.BerlogicEngine.Agency.Number= config.AgencyNumber;
            configuration.BerlogicEngine.Agency.Password= config.AgencyPassword;
            configuration.BerlogicEngine.Agency.Salespoint= config.AgencySalespoint;
            configuration.Database.Host=config.DatabaseHost;
            configuration.Database.Name= config.DatabaseName;
            configuration.Database.Password= config.DatabasePassword;
            configuration.Database.Port = config.DatabasePort;
            configuration.Database.RemoteHost=config.DatabaseRemote;
            configuration.Database.User= config.DatabaseUser;
            configuration.SearchEngine.FormLimit= config.FormLimit;
            configuration.SearchEngine.PageLimit= config.PageLimit;
            configuration.SearchEngine.SearchLimit= config.SearchLimit;
            configuration.Serialize();
            configuration.SaveToFile(PathToCommonConfigFile.NAME,PathToCommonConfigFile.FOLDER);
            //string path = @"D:\Common Documents\visual studio 2015\Projects\B2B_App\B2B_App\bin\x86\Debug\AppX\ConfigFiles\" + ConfigFileName;
            //CommonConfiguration.SaveToFile(path,configuration,true);
        }

        private bool FileExist()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            path = storageFolder.Path + "\\" + ConfigFileName;
            PathToCommonConfigFile.FOLDER = storageFolder;
            PathToCommonConfigFile.NAME = ConfigFileName;
            try
            {
                IAsyncOperation<StorageFile> file = StorageFile.GetFileFromPathAsync(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class PathToCommonConfigFile
    {
        public static StorageFolder FOLDER;
        public static string NAME;
    }
}
