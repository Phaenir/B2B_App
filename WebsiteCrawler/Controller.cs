using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteCrawler.Database;
using WebsiteCrawler.FTP;

namespace WebsiteCrawler
{
    /// <summary>
    /// In this class we set initial dates from whole solution
    /// </summary>
    class Controller
    {
        /// <summary>
        /// the list of string variables where in xml format with website template preferences stored
        /// </summary>
        private List<string> WebsiteDomList { get; }
        /// <summary>
        /// the list of website names that need to investigate
        /// </summary>
        public List<string> SiteNames { get; }
        /// <summary>
        /// the list of routes that need to investigate
        /// </summary>
        public List<Route> FlightLegs { get; }
        /// <summary>
        /// departure date
        /// </summary>
        public string DepartureDate { get; private set; }
        /// <summary>
        /// arrival date
        /// </summary>
        public string ArrivalDate { get; private set; }
        /// <summary>
        /// the path where common configuration of application saved
        /// </summary>
        private string ConfigFilePath { get; set; }
        /// <summary>
        /// object where application configuration stored
        /// </summary>
        public CommonConfig Config { get; private set; }
        /// <summary>
        /// the list of objects where website preferences stored in variables
        /// </summary>
        public List<Template> WebsiteTemplates { get; }
        /// <summary>
        /// the model that define rules of get and save configuration of application
        /// </summary>
        private readonly CommonConfigurationModel _configuration=new CommonConfigurationModel();


        public Controller()
        {
            SiteNames=new List<string>();
            FlightLegs=new List<Route>();
            WebsiteDomList=new List<string>();
            WebsiteTemplates=new List<Template>();
        }
        /// <summary>
        /// In this method we receive data that was defined in B2B_app application and required for websites and web service investigation
        /// </summary>
        public void GetDataFromUser()
        {
            string data = RemoteSave.GetContentFromFtp("conf", RemoteSave.State.INTERMEDIATE);
            var strArr = data.Split(Environment.NewLine.ToCharArray());
            List<string> condData= strArr.Where(s => !String.IsNullOrEmpty(s)).ToList();
            var temp = condData[0];
            var temp2 = temp.Split(';');
            foreach (string s in temp2.Where(s => !String.IsNullOrEmpty(s)))
            {
                SiteNames.Add(s);
            }
            temp = condData[1];
            temp2 = temp.Split(';');
            bool flag;
            foreach (string s in temp2)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    var temp3 = s.Split('-');
                    Route route = new Route();
                    flag = true;
                    foreach (string s1 in temp3.Where(s1 => !String.IsNullOrEmpty(s1)))
                    {
                        if (flag)
                        {
                            route.Departure = s1;
                            flag = false;
                        }
                        else
                        {
                            if (s1 != '-'.ToString())
                            {
                                route.Arrival = s1;
                            }
                        }
                    }
                    FlightLegs.Add(route);
                }
            }
            temp = condData[2];
            temp2 = temp.Split(';');
            flag = true;
            foreach (string s in temp2)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    if (flag)
                    {
                        // 2016-07-20T15:00:00Z
                        DepartureDate= s;
                        flag = false;
                    }
                    else
                    {
                        if (s!=';'.ToString())
                        {
                            ArrivalDate=s;
                        }
                    }                    
                }
            }
            temp = condData[3];
            temp2 = temp.Split(';');
            ConfigFilePath = temp2[0];
            Config=new CommonConfig();
            Config = _configuration.GetConfiguration(ConfigFilePath);
            foreach (string siteName in SiteNames)
            {
                WebsiteDomList.Add(RemoteSave.GetContentFromFtp(siteName,RemoteSave.State.TEMPLATE));
            }
            TemplateConfigModel template=new TemplateConfigModel();
            foreach (string s in SiteNames)
            {                
                WebsiteTemplates.Add(template.GetConfiguration(s));
            }
        }
    }
}
