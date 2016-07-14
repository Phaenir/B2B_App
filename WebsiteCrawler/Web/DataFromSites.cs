using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebsiteCrawler.Database;

namespace WebsiteCrawler.Web
{
    /// <summary>
    /// Class that define methods to get information from websites
    /// </summary>
    class DataFromSites
    {
        /// <summary>
        /// define object variable that store application configuration and investigation preferences
        /// </summary>
        private readonly Controller _controller;

        public DataFromSites(Controller controller)
        {
            _controller = controller;
        }
        /// <summary>
        /// Method that fill forms on website
        /// </summary>
        /// <param name="site">index of site that need to investigate</param>
        /// <param name="leg">index of route that need to investigate</param>
        public void FillForm(int site, int leg)
        {
            IWebDriver driver=new ChromeDriver();
            driver.Navigate().GoToUrl(new Uri(_controller.WebsiteTemplates[site].CommonInfo.WebsiteUrl));
            WebDriverWait wait=new WebDriverWait(driver,new TimeSpan(0,0,1200));
            IWebElement query;
            string request = null;
                try
                {
                    request = _controller.WebsiteTemplates[site].SearchEngine.DeparturePoint.Tag +"["+
                              _controller.WebsiteTemplates[site].SearchEngine.DeparturePoint.Attr + "='"+
                              _controller.WebsiteTemplates[site].SearchEngine.DeparturePoint.Name+"']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.SendKeys(_controller.FlightLegs[leg].Departure);
                    Thread.Sleep(5000);
                }
                catch (Exception exception)
                {
                    Debug.Assert(true,exception.Message);
                    Thread.Sleep(5000);
                }
            try
            {
                request = _controller.WebsiteTemplates[site].SearchEngine.ArrivalPoint.Tag + "[" +
                              _controller.WebsiteTemplates[site].SearchEngine.ArrivalPoint.Attr + "='" +
                              _controller.WebsiteTemplates[site].SearchEngine.ArrivalPoint.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.SendKeys(_controller.FlightLegs[leg].Arrival);
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                Thread.Sleep(5000);
            }
            try
            {
                request = _controller.WebsiteTemplates[site].SearchEngine.DepartureDate.Tag + "[" +
                              _controller.WebsiteTemplates[site].SearchEngine.DepartureDate.Attr + "='" +
                              _controller.WebsiteTemplates[site].SearchEngine.DepartureDate.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                string str = $"{DateTime.Parse(_controller.DepartureDate):dd.MM.yyyy}";  
                query.SendKeys(str);
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                Thread.Sleep(5000);
            }
            try
            {
                request = _controller.WebsiteTemplates[site].SearchEngine.ArrivalDate.Tag + "[" +
                              _controller.WebsiteTemplates[site].SearchEngine.ArrivalDate.Attr + "='" +
                              _controller.WebsiteTemplates[site].SearchEngine.ArrivalDate.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                string str = $"{DateTime.Parse(_controller.ArrivalDate):dd.MM.yyyy}";
                query.SendKeys(str);
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                Thread.Sleep(5000);
            }
            try
            {
                request = _controller.WebsiteTemplates[site].SearchEngine.ConfirmationButton.Tag + "[" +
                              _controller.WebsiteTemplates[site].SearchEngine.ConfirmationButton.Attr + "='" +
                              _controller.WebsiteTemplates[site].SearchEngine.ConfirmationButton.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.Click();
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                query = driver.FindElement(By.CssSelector(request));
                        query.Click();                   
            }
            Thread.Sleep(15000);

            try
            {
                request = _controller.WebsiteTemplates[site].AdditionalInfo.Detail.Tag + "[" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.Detail.Attr + "='" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.Detail.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.Click();

                request = _controller.WebsiteTemplates[site].AdditionalInfo.ListAllowed.Tag + "[" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.ListAllowed.Attr + "='" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.ListAllowed.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.Click();
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                Thread.Sleep(5000);
            }
            try
            {
                request = _controller.WebsiteTemplates[site].AdditionalInfo.OnlyDirect.Tag + "[" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.OnlyDirect.Attr + "='" +
                              _controller.WebsiteTemplates[site].AdditionalInfo.OnlyDirect.Name + "']";
                query =
                        driver.FindElement(By.CssSelector(request));
                query.Click();
                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
                Thread.Sleep(5000);
            }

            string page = driver.PageSource;
            driver.Close();
            driver.Quit();
            ParseData(page, _controller.SiteNames[site],site, leg);
        }
        /// <summary>
        /// Method that parse data from result page from investigated website
        /// </summary>
        /// <param name="page">DOM of the result page</param>
        /// <param name="siteName">name of the website</param>
        /// <param name="site">index of the investigated website</param>
        /// <param name="leg">index of the investigated routes</param>
        private void ParseData(string page, string siteName, int site, int leg)
        {
            HtmlDocument document = new HtmlDocument {OptionFixNestedTags = true};
            document.Load(new StringReader(page));
            var div = document.DocumentNode.Descendants(_controller.WebsiteTemplates[site].ResultEngine.DeparturePoint.Tag).Where(d=>d.Attributes.Contains(_controller.WebsiteTemplates[site].ResultEngine.DeparturePoint.Attr) &&d.Attributes[_controller.WebsiteTemplates[site].ResultEngine.DeparturePoint.Attr].Value.Contains(_controller.WebsiteTemplates[site].ResultEngine.DeparturePoint.Name)).GetEnumerator();
            while (div.MoveNext())
            {
                HtmlNode htmlNode = div.Current;                
                var aircompany = htmlNode.ChildNodes[1].InnerText.Trim('\r', '\t', '\n').Split('\r', '\t', '\n', '<', '>', '-').ToList();
                aircompany.RemoveAll(String.IsNullOrEmpty);

                var time = htmlNode.ChildNodes[5].InnerText.Trim('\r', '\t', '\n').Split('\r', '\t', '\n', '<', '>', '-').ToList();
                time.RemoveAll(String.IsNullOrEmpty);
                List<string> arr = time.Where(s => s.Contains(":")).ToList();
                time = htmlNode.ChildNodes[9].InnerText.Trim('\r', '\t', '\n').Split('\r', '\t', '\n','<','>','-').ToList();
                time.RemoveAll(String.IsNullOrEmpty);
                arr.AddRange(time.Where(s => s.Contains(":")));

                var price= htmlNode.ChildNodes[13].InnerText.Trim('\r', '\t', '\n').Split('\r', '\t', '\n', '<', '>', '-').ToList();
                price.RemoveAll(String.IsNullOrEmpty);
                string cost= (from s in price from c in s.ToCharArray() where c >= '0' && c <= '9' select c).Aggregate<char, string>(null, (current, c) => current + c);
                SaveDataInDatabase(arr[0], arr[1], arr[2], arr[3], cost, aircompany,siteName, leg);
            }
        }
        /// <summary>
        /// Method that save received data in tables of database
        /// </summary>
        /// <param name="dep_time">departure time</param>
        /// <param name="arr_time">arrival time</param>
        /// <param name="rDepTime">return departure time</param>
        /// <param name="rArrTime">return arrival time</param>
        /// <param name="cost">price of flight</param>
        /// <param name="airline">airline company that provide the flight</param>
        /// <param name="siteName">the name of website</param>
        /// <param name="leg">index of investigated route</param>
        private void SaveDataInDatabase(string dep_time, string arr_time, string rDepTime, string rArrTime, string cost, List<string> airline, string siteName, int leg)
        {
            Roundtrip roundtrip=new Roundtrip();
            SearchResult result=new SearchResult();
            Database.Database database = new Database.Database(_controller.Config.DatabaseRemote, _controller.Config.DatabaseUser, _controller.Config.DatabasePassword, _controller.Config.DatabaseName, (uint)_controller.Config.DatabasePort);

            if (_controller.ArrivalDate!=null)
            {
                roundtrip.ArrDate =DateTime.Parse($"{_controller.ArrivalDate:d}");
                roundtrip.DepTime=DateTime.Parse(rArrTime);
                roundtrip.ArrTime=DateTime.Parse(rDepTime);
                roundtrip.DepDate = roundtrip.ArrTime>roundtrip.DepTime ? roundtrip.ArrDate : roundtrip.ArrDate.AddDays(1);
                roundtrip.Departure=_controller.FlightLegs[leg].Arrival;
                roundtrip.Arrival = _controller.FlightLegs[leg].Departure;
                roundtrip.ServiceClass = 2;
                roundtrip.ValidateCarrier = database.GetAirlineCode(airline[0]);
            }
            result.SearchTime=DateTime.Now;
            result.DepDate=DateTime.Parse($"{_controller.DepartureDate:d}");
            result.DepTime=DateTime.Parse(dep_time);
            result.ArrTime=DateTime.Parse(arr_time);
            result.ArrDate = result.ArrTime<result.DepTime ? result.DepDate.AddDays(1) : result.DepDate;
            result.Price = decimal.Parse(cost);
            result.ValidateCarrier = database.GetAirlineCode(airline[0]);
            result.ServiceClass = 2;
            result.Type1 = 3;
            result.Url =siteName;
            result.Departure = _controller.FlightLegs[leg].Departure;
            result.Arrival = _controller.FlightLegs[leg].Arrival;
            if (roundtrip.ValidateCarrier==null)
            {
                roundtrip.ValidateCarrier = result.ValidateCarrier;
            }
            if (roundtrip.ArrTime!=null)
            {
                int rid = database.RoundtripIsExistsInDatabase(roundtrip);
                if (rid!=0)
                {
                    result.Rtrip = 1;
                    result.RoundtripId = rid;
                }
                else
                {
                    rid = database.InsertRoundtripsToDatabase(roundtrip);
                    result.Rtrip = 1;
                    result.RoundtripId = rid;
                }
            }
            if (database.SearchResultsIsExistsInDatabase(result)==0)
            {
                var n= database.InsertSearchResultsToDatabase(result);
            }
        }
    }
}
