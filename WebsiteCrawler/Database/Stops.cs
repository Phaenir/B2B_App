using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteCrawler.Database
{
    public class Stops
    {
        public int SearchId { get; set; }
        public string Arrival { get; set; }
        public DateTime ArrDate { get; set; }
        public DateTime ArrTime { get; set; }
        public string OperateCarrier { get; set; }
        public int OperateFlightNumber { get; set; }
        public string Departure { get; set; }
        public DateTime DepDate { get; set; }
        public DateTime DepTime { get; set; }
    }
}
