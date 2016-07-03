﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool IsSame(CommonConfig start, CommonConfig end)
        {
            return start.Equals(end);
        }

        public void Copy(CommonConfig start)
        {
            PageLimit = start.PageLimit;
            FormLimit = start.FormLimit;
            SearchLimit = start.SearchLimit;

            AgencyName = start.AgencyName;
            AgencyNumber = start.AgencyNumber;
            AgencyPassword = start.AgencyPassword;
            AgencySalespoint = start.AgencySalespoint;

            DatabaseName = start.DatabaseName;
            DatabasePassword = start.DatabasePassword;
            DatabasePort = start.DatabasePort;
            DatabaseRemote = start.DatabaseRemote;
            DatabaseUser = start.DatabaseUser;
            DatabaseHost = start.DatabaseHost;
        }
    }
}
