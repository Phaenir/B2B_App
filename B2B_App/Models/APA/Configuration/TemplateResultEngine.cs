using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateResultEngine
    {
        public HtmlTags DeparturePoint { get; set; }
        public HtmlTags ArrivalPoint { get; set; }
        public HtmlTags DepartureDate { get; set; }
        public HtmlTags ArrivalDate { get; set; }
        public HtmlTags AirlineNumber { get; set; }
        public HtmlTags AirlineName { get; set; }
        public HtmlTags Tariff { get; set; }
        public HtmlTags Tax { get; set; }
        public HtmlTags Fee { get; set; }
        public HtmlTags Price { get; set; }
        public HtmlTags DepartureTime { get; set; }
        public HtmlTags ArrivalTime { get; set; }

        public TemplateResultEngine()
        {
            DeparturePoint=new HtmlTags();
            ArrivalPoint=new HtmlTags();
            DepartureDate=new HtmlTags();
            ArrivalDate=new HtmlTags();
            AirlineName=new HtmlTags();
            AirlineNumber=new HtmlTags();
            DepartureTime=new HtmlTags();
            ArrivalTime=new HtmlTags();
            Tariff=new HtmlTags();
            Tax=new HtmlTags();
            Fee=new HtmlTags();
            Price=new HtmlTags();
        }
        public TemplateResultEngine(TemplateResultEngine resultEngine)
        {
            DeparturePoint = resultEngine.DeparturePoint;
            DepartureDate = resultEngine.DepartureDate;
            DepartureTime = resultEngine.DepartureTime;
            ArrivalPoint = resultEngine.ArrivalPoint;
            ArrivalDate = resultEngine.ArrivalDate;
            AirlineName = resultEngine.AirlineName;
            AirlineNumber = resultEngine.AirlineNumber;
            Tariff = resultEngine.Tariff;
            Tax = resultEngine.Tax;
            Fee = resultEngine.Fee;
            Price = resultEngine.Price;
        }

        public bool IsSame(TemplateResultEngine resultEngine)
        {
            if (DeparturePoint != resultEngine.DeparturePoint)
                return false;
            if (DepartureDate != resultEngine.DepartureDate)
                return false;
            if (DepartureTime != resultEngine.DepartureTime)
                return false;
            if (ArrivalPoint != resultEngine.ArrivalPoint)
                return false;
            if (ArrivalDate != resultEngine.ArrivalDate)
                return false;
            if (ArrivalTime != resultEngine.ArrivalTime)
                return false;
            if (AirlineName != resultEngine.AirlineName)
                return false;
            if (AirlineNumber != resultEngine.AirlineNumber)
                return false;
            if (Tariff != resultEngine.Tariff)
                return false;
            if (Tax != resultEngine.Tax)
                return false;
            if (Fee != resultEngine.Fee)
                return false;
            if (Price != resultEngine.Price)
                return false;
            return true;
        }
    }
}
