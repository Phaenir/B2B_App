using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WatiN;
using WatiN.Core;
using MvcContrib.TestHelper.WatiN;

namespace WebsiteCrawler.Web
{
    class DataFromSites
    {
        private Controller _controller;
        public DataFromSites(Controller controller)
        {
            _controller = controller;
        }
        public void FillForm()
        {
            IWebDriver driver=new ChromeDriver();
            driver.Navigate().GoToUrl(new Uri("http://www.aviabilet.eu/de/index"));
            WebDriverWait wait=new WebDriverWait(driver,new TimeSpan(0,0,60));
            wait.Until(w => driver.FindElements(By.CssSelector("[name='depapt1'")).ToList().Any(o => o.Displayed));



           // IWebElement elem = driver.FindElement(By.XPath("//*[@id='depapt1']/input"));
           // String js = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible';";
            //((JavaScriptExecutor)driver).executeScript(js, elem);
            IWebElement query = driver.FindElement(By.Id("depapt1"));
            query.SendKeys("BERLIN");
            query = driver.FindElement(By.Id("dstapt1_name"));
            query.SendKeys("Moscow");
            query = driver.FindElement(By.Id("depdate1_human"));
            query.SendKeys("07.08.2016");
            query = driver.FindElement(By.Id("retdate1_human"));
            query.SendKeys("14.08.2016");
            query = driver.FindElement(By.Id("search_btn"));
            query.Submit();
            var source = driver.PageSource;
            //query.FindElement(By.LinkText("Найти билеты"));
            //query.FindElement(By.ClassName("name"));
            query.Submit();
            query.FindElement(By.ClassName("submitbutton jqTransformButton")).Click();
            query.Click();
            //query.FindElement(By.ClassName("arrow"));
            var pageSource = driver.PageSource;
            //  wait.Until((d) => { return d.Title.ToLower().StartsWith("BERLIN"); });
            //  System.Console.WriteLine("Page Title is: "+driver.Title);
            driver.Quit();

            //string str;
            //str = Browser.InvokeScript("eval", new string[] {"document.documentElement.outerHTML;"});

        }

        public void test()
        {
            WatiN.Core.IE wiFireFox=new IE();
            wiFireFox.GoTo(new Uri("http://tutu.ru"));
            var buttonCollection = wiFireFox.Buttons;
            var domContainer = wiFireFox.DomContainer;
            var elementCollection = wiFireFox.Elements;
            var divCollection = wiFireFox.Divs;
        }
    }
}
