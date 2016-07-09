using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase
{
    public class Airline
    {
        public string Iata { get; set; }
        public string Name { get; set; }
        public Airline() { }

        public Airline(string iata, string name)
        {
            Iata = iata;
            Name = name;
        }
    }
}
