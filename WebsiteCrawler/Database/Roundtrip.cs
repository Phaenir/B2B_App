using System;

namespace WebsiteCrawler.Database
{
    /// <summary>
    /// The class that describes fields in roundtrip table in database
    /// </summary>
    public class Roundtrip
    {
        /// <summary>
        /// ID of row where saved return flight
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// departure airport (that normally is same as arrival airport in search_result
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// arrival airport (that normally is same as departure airport in search_result
        /// </summary>
        public string Arrival { get; set; }
        /// <summary>
        /// departure date
        /// </summary>
        public DateTime DepDate { get; set; }
        /// <summary>
        /// departure boarding time
        /// </summary>
        public DateTime DepTime { get; set; }
        /// <summary>
        /// arrival date
        /// </summary>
        public DateTime ArrDate { get; set; }
        /// <summary>
        /// landing time
        /// </summary>
        public DateTime ArrTime { get; set; }
        /// <summary>
        /// service class on the board
        /// </summary>
        public int ServiceClass { get; set; }
        /// <summary>
        /// airline that sells and validate the chosen flight
        /// </summary>
        public string ValidateCarrier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ValidateCarrierNumber { get; set; }
        /// <summary>
        /// the number of airline board
        /// </summary>
        public string OperateCarrier { get; set; }
        /// <summary>
        /// the airline that in fact realize the flight
        /// </summary>
        public int OperateCarrierNumber { get; set; }
        /// <summary>
        /// the number of airline board of operating company
        /// </summary>
        public int TravelDuration { get; set; }
    }
}
