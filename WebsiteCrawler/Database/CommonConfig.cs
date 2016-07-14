namespace WebsiteCrawler.Database
{
    class CommonConfig
    {
        public string AgencyName { get; set; }
        public string AgencyNumber { get; set; }
        public string AgencyPassword { get; set; }
        public string AgencySalespoint { get; set; }

        public string DatabaseHost { get; set; }
        public string DatabaseRemote { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabaseName { get; set; }
        public int DatabasePort { get; set; }

        public int FormLimit { get; set; }
        public int PageLimit { get; set; }
        public int SearchLimit { get; set; }

        public bool IsSame(CommonConfig start)
        {
            if (PageLimit==start.PageLimit && FormLimit==start.FormLimit && SearchLimit==start.SearchLimit && AgencyName==start.AgencyName && AgencyNumber==start.AgencyNumber && AgencyPassword==start.AgencyPassword && AgencySalespoint==start.AgencySalespoint && DatabaseName==start.DatabaseName && DatabasePassword==start.DatabasePassword && DatabasePort==start.DatabasePort && DatabaseRemote == start.DatabaseRemote && DatabaseUser == start.DatabaseUser && DatabaseHost == start.DatabaseHost)
            {
                return true;
            }
            return false;
        }
    }
}
