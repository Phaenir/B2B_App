namespace B2B_App.Models.APA.Configuration
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
    }
}
