using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class City
    {

        public string Iata { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string Timezone { get; set; }
        public string ParentCountry { get; set; }
        public City() { }

        public City(string iata, string name,string coord, string timezone, string country)
        {
            Iata = iata;
            Name = name;
            Coordinates = coord;
            Timezone = timezone;
            ParentCountry = country;
        }
    }
}
