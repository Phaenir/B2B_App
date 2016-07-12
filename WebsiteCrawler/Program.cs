using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteCrawler.Web;

namespace WebsiteCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller=new Controller();
            controller.GetDataFromUser();
            DataFromGds fromGds=new DataFromGds();
            fromGds.Start(controller, controller.FlightLegs[0]);
            //DataFromSites fromSites=new DataFromSites(controller);
            //fromSites.FillForm();
           //fromSites.test();
        }
    }
}
