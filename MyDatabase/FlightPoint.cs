using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    /// <summary>
    /// Class that describes information about one flight leg
    /// </summary>
    public class FlightPoint
    {

        /// <summary>
        /// 
        /// </summary>
        public string Iata { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; }
        /// <summary>
        /// 
        /// </summary>
        public string CityCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public string CountryName { get; }
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public FlightPoint() { }

        /// <summary>
        /// Constructor where initialize object variables
        /// </summary>
        /// <param name="iata">iata airport code</param>
        /// <param name="name">airport name</param>
        /// <param name="cord">airport coordinates</param>
        /// <param name="timeZone">timezone</param>
        /// <param name="cityname">city name where placed airport</param>
        /// <param name="citycode">iata city code</param>
        /// <param name="countryname">country name</param>
        /// <param name="countrycode">iata country code</param>
        public FlightPoint(string iata, string name, string cord, string timeZone, string cityname,string citycode, string countryname, string countrycode)
        {
            Iata = iata;
            Name = name;
            Coordinates = cord;
            TimeZone = timeZone;
            CityName = cityname;
            CityCode = citycode;
            CountryName = countryname;
            CountryCode = countrycode;
        }
    }
}
