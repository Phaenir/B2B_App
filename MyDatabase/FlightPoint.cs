using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class FlightPoint
    {

        public string Iata { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string TimeZone { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public FlightPoint() { }

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
