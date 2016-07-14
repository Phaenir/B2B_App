using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteCrawler.Web;

namespace WebsiteCrawler
{
    static class Program
    {
        static void Main(string[] args)
        {
            Controller controller=new Controller();
            controller.GetDataFromUser();
            DataFromSites fromSites = new DataFromSites(controller);
            DataFromGds fromGds =new DataFromGds();
            int siteAmount = controller.WebsiteTemplates.Count;
            int legsAmount = controller.FlightLegs.Count;


            List<Task> tasks = new List<Task>
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < legsAmount; i++)
                    {
                        fromGds.Start(controller, controller.FlightLegs[i]);
                    }
                }),
                Task.Run(() =>
                {
                    for (int i = 0; i < siteAmount; i++)
                    {
                        for (int j = 0; j < legsAmount; j++)
                        {
                            fromSites.FillForm(i, j);
                        }
                    }
                })
            };
            Task.WaitAll(tasks.ToArray());
        }
    }
}
