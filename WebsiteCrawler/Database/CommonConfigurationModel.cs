namespace WebsiteCrawler.Database
{
    class CommonConfigurationModel
    {
        public CommonConfig GetConfiguration(string path)
        {
            CommonConfig config=new CommonConfig();
            var configuration = CommonConfiguration.LoadFromFile(path);
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
    }
}
