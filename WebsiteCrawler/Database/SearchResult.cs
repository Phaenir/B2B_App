using System;

namespace WebsiteCrawler.Database
{
    /// <summary>
    /// Class that describes search_result table fields where we storage results of investigation
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Date and time of investigation
        /// </summary>
        public DateTime SearchTime { get; set; }
        /// <summary>
        /// target online resource that was investigated
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Is this target our web-service, competitor or partner
        /// </summary>
        public int Type1 { get; set; }
        /// <summary>
        /// Departure airport
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// arrival airport (final point, if in route we have stop overs)
        /// </summary>
        public string Arrival { get; set; }
        /// <summary>
        /// date of departure
        /// </summary>
        public DateTime DepDate { get; set; }
        /// <summary>
        /// departure boarding time
        /// </summary>
        public DateTime DepTime { get; set; }
        /// <summary>
        /// date of arrival
        /// </summary>
        public DateTime ArrDate { get; set; }
        /// <summary>
        /// landing time
        /// </summary>
        public DateTime ArrTime { get; set; }
        /// <summary>
        /// if we investigate roundtrip routes (with return flight)
        /// </summary>
        public byte Rtrip { get; set; }
        /// <summary>
        /// ID of row in roundtrip table where saved information about return flight
        /// </summary>
        public int RoundtripId { get; set; }
        /// <summary>
        /// service class on board
        /// </summary>
        public int ServiceClass { get; set; }
        /// <summary>
        /// airline that sells and validate the chosen flight
        /// </summary>
        public string ValidateCarrier { get; set; }
        /// <summary>
        /// the number of airline board
        /// </summary>
        public int ValidateCarrierNumber { get; set; }
        /// <summary>
        /// the airline that in fact realize the flight
        /// </summary>
        public string OperateCarrier { get; set; }
        /// <summary>
        /// the number of airline board of operating company
        /// </summary>
        public int OperateCarrierNumber { get; set; }
        /// <summary>
        /// duration of flight
        /// </summary>
        public int TravelDuration { get; set; }
        /// <summary>
        /// Tariff
        /// </summary>
        public decimal Tariff { get; set; }
        /// <summary>
        /// Taxes
        /// </summary>
        public decimal Taxes { get; set; }
        /// <summary>
        /// charges from consolidators and agents
        /// </summary>
        public decimal Fee { get; set; }
        /// <summary>
        /// additional charges like SSr (Special services - animal transportation, special food on the board, abnormal luggage and etc
        /// </summary>
        public decimal Charges { get; set; }
        /// <summary>
        /// total price for the flight
        /// </summary>
        public decimal Price { get; set; }
    }
}
