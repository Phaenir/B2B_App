using System;

namespace MyDatabase
{
    /// <summary>
    /// Class that describes view in database with results of investigation used as preview
    /// </summary>
    public class ResultView
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DepartureTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeparturePoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte Roundtrip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RoundtripDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RoundtripTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ValidateCarrierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ValidateCarrierNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OperateCarrierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OperateCarrierNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
