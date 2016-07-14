using System;

namespace WebsiteCrawler.Database
{
    /// <summary>
    /// This class describes object where during one route we have points on stops like TXL (Berlin) - LON (London) - NYC (New York). In that example LON is stop over, since we could stay there limited time without possibility to leave airport.
    /// </summary>
    public class Stops
    {
        /// <summary>
        /// we save ID of current search request since in Database relation between search_result and stops is '1-N'
        /// </summary>
        public int SearchId { get; set; }
        /// <summary>
        /// from airport where we start flight we arrive to intermediate point
        /// </summary>
        public string Arrival { get; set; }
        /// <summary>
        /// date when we arrive to stop over
        /// </summary>
        public DateTime ArrDate { get; set; }
        /// <summary>
        /// time when we arrive to stop over
        /// </summary>
        public DateTime ArrTime { get; set; }
        /// <summary>
        /// airline company that in fact make flight
        /// </summary>
        public string OperateCarrier { get; set; }
        /// <summary>
        /// and number of race
        /// </summary>
        public int OperateFlightNumber { get; set; }
        /// <summary>
        /// the airport where we landing after stop over
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// Date of landing
        /// </summary>
        public DateTime DepDate { get; set; }
        /// <summary>
        /// Time of landing
        /// </summary>
        public DateTime DepTime { get; set; }
    }
}
