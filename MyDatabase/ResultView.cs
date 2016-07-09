using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class ResultView
    {
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public byte Roundtrip { get; set; }
        public DateTime RoundtripDate { get; set; }
        public DateTime RoundtripTime { get; set; }
        public string ValidateCarrierName { get; set; }
        public int ValidateCarrierNumber { get; set; }
        public string OperateCarrierName { get; set; }
        public int OperateCarrierNumber { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}
