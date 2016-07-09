using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class Airport
    {

        public string Iata { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string Timezone { get; set; }
        public string ParentCity { get; set; }
        public Airport() { }

        public Airport(string iata, string name, string coord, string timezone, string city)
        {
            Iata = iata;
            Name = name;
            Coordinates = coord;
            Timezone = timezone;
            ParentCity = city;
        }
    }
}
