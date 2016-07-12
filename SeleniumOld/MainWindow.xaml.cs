using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumOld.de.berlogic.devlt;

namespace SeleniumOld
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IWebDriver driver=new ChromeDriver();
            driver.Navigate().GoToUrl("http://test.ru");
            
        }

        private void GetDataFromGDS()
        {
            var WDSL_URL = new Uri("https://devlt.berlogic.de:444/Partner/Avia?wsdl ");
            var Service_URL = new Uri("https://devlt.berlogic.de:444/Partner/Avia");
            var Agency_Code = "00001066";
            var Sales_Point = "pegastour.ru";
            var Agent_Code = "pegastour.ru";
            var Agent_Password = "cT7CzB0<c?>e<";

            var client = new de.berlogic.devlt.Avia();
            var useDefaultCredentials = client.UseDefaultCredentials;
            client.Url = Service_URL.AbsoluteUri;

            routeSegment route = new routeSegment
            {
                beginLocation = "DME",
                endLocation = "TXL",
                date = DateTime.Parse("2016-07-20T15:00:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                dateSpecified = true,
                departureTimeFrom = null,
                departureTimeTo = null
            };
            routeSegment[] routes = new routeSegment[1];
            routes[0] = route;
            flightSearchSettingsEntry adult = new flightSearchSettingsEntry
            {
                key = passengerCategory.ADULT,
                value = 1,
                keySpecified = true,
                valueSpecified = true
            };

            flightSearchSettingsEntry child = new flightSearchSettingsEntry
            {
                key = passengerCategory.CHILD,
                value = 1,
                keySpecified = true,
                valueSpecified = true
            };
            flightSearchSettingsEntry infant = new flightSearchSettingsEntry
            {
                key = passengerCategory.INFANT,
                value = 1,
                keySpecified = true,
                valueSpecified = true
            };
            flightSearchSettings settings = new flightSearchSettings
            {
                agencyCode = Agency_Code,
                salesPoint = Sales_Point,
                agentCode = Agent_Code,
                agentPassword = Agent_Password,
                dateTolerance = 0,
                eticketsOnly = false,

                lang = "ru",
                mixedVendors = true,
                preferredCurrency = "RUB",
                serviceClass = serviceClass.ECONOM,
                skipConnected = false,
                route = new[] { route },
                seats = new[] { adult, child, infant },
                serviceClassSpecified = true

            };

            client.authenticate(Agent_Code, Agent_Password);

            var soapProtocolVersion = client.SoapVersion;
            var site = client.Site;
            var userAgent = client.UserAgent;
            var response = client.searchFlights(settings);
        }
    }
}
