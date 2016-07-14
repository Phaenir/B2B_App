using System;

namespace B2B_App.Models.APA.Configuration
{
    class Route
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Delimeter { get; } = "-";
        public string FlightLeg { get; private set; }

        public bool FormRoute()
        {
            if (String.IsNullOrEmpty(Departure)||String.IsNullOrEmpty(Arrival))
            {
                return false;
            }
            FlightLeg = Departure + Delimeter + Arrival;
            return true;
        }
    }
}
