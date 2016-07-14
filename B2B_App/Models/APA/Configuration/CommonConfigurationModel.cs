using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;

namespace B2B_App.Models.APA.Configuration
{
    class CommonConfigurationModel
    {
        public readonly string ConfigFileName = "ConfigFile.xml";
        public string Path;
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
            CommonConfiguration temp = common;
            var t = Task.Run(async () =>
            {
                await temp.SaveToFile(PathToCommonConfigFile.NAME, PathToCommonConfigFile.FOLDER);

            });
            t.Wait();
            common = temp;
        }

        public CommonConfig GetConfiguration()
        {
            CommonConfig config=new CommonConfig();
            CommonConfiguration configuration;
            bool isExist=true;
            var t = Task.Run(async () =>
            {
               isExist=  await FileExist();

            });
            t.Wait();
            if (!isExist)
            {
                Init(out configuration);
            }
            else
            {
                configuration = CommonConfiguration.LoadFromFile(Path);
            }
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
            CommonConfiguration configuration = CommonConfiguration.LoadFromFile(Path);
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
            var t = Task.Run(async () =>
            {
                await configuration.SaveToFile(PathToCommonConfigFile.NAME, PathToCommonConfigFile.FOLDER);

            });
            t.Wait();
            
        }

        private async Task<bool> FileExist()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            Path = storageFolder.Path + "\\" + ConfigFileName;
            PathToCommonConfigFile.FOLDER = storageFolder;
            PathToCommonConfigFile.NAME = ConfigFileName;
            try
            {
                string contents = null;
                if (storageFolder.TryGetItemAsync(ConfigFileName)!=null)
                {
                    StorageFile file =await storageFolder.GetFileAsync(ConfigFileName);
                    contents = FileIO.ReadTextAsync(file).ToString();
                }
                if (String.IsNullOrEmpty(contents))
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                Debug.Assert(true,exception.Message);
                return false;
            }
        }
    }

    /// <summary>
    /// Path builder under rules of .NET Framework 5.0 +
    /// </summary>
    public class PathToCommonConfigFile
    {
        public static StorageFolder FOLDER;
        public static string NAME;
    }
}
