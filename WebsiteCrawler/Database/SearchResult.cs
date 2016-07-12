using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCrawler.Database
{
    public class SearchResult
    {
        public DateTime SearchTime { get; set; }
        public string Url { get; set; }
        public int Type1 { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepDate { get; set; }
        public DateTime DepTime { get; set; }
        public DateTime ArrDate { get; set; }
        public DateTime ArrTime { get; set; }
        public byte Rtrip { get; set; }
        public int RoundtripId { get; set; }
        public int ServiceClass { get; set; }
        public string ValidateCarrier { get; set; }
        public int ValidateCarrierNumber { get; set; }
        public string OperateCarrier { get; set; }
        public int OperateCarrierNumber { get; set; }
        public int TravelDuration { get; set; }
        public decimal Tariff { get; set; }
        public decimal Taxes { get; set; }
        public decimal Fee { get; set; }
        public decimal Charges { get; set; }
        public decimal Price { get; set; }
    }
}
