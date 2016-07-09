using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class Country
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public Country() { }

        public Country(string iata, string name)
        {
            Iata = iata;
            Name = name;
        }

    }
}
