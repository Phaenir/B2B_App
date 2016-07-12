using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCrawler.Database;
using WebsiteCrawler.FTP;

namespace WebsiteCrawler
{
    
    class Controller
    {
        public List<string> WebsiteDomList { get; }
        public List<string> SiteNames { get; }
        public List<Route> FlightLegs { get; }
        public string DepartureDate { get; private set; }
        public string ArrivalDate { get; private set; }
        public string ConfigFilePath { get; private set; }
        public CommonConfig Config { get; private set; }
        public List<Template> WebsiteTemplates { get; }
        private readonly CommonConfigurationModel _configuration=new CommonConfigurationModel();


        public Controller()
        {
            SiteNames=new List<string>();
            FlightLegs=new List<Route>();
            WebsiteDomList=new List<string>();
            WebsiteTemplates=new List<Template>();
        }
        public void GetDataFromUser()
        {
            string data = RemoteSave.GetContentFromFtp("conf", RemoteSave.State.INTERMEDIATE);
            var strArr = data.Split(Environment.NewLine.ToCharArray());
            List<string> condData= strArr.Where(s => !String.IsNullOrEmpty(s)).ToList();
            string temp;
            temp = condData[0];
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
