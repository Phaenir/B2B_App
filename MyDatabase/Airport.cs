namespace MyDatabase
{
    /// <summary>
    /// Class, that describes fields in airport table in database
    /// </summary>
    public class Airport
    {

        /// <summary>
        /// IATA code of airport
        /// </summary>
        public string Iata { get; set; }
        /// <summary>
        /// Full name of airport
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// GPS coordinates of airport
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// timezone
        /// </summary>
        public string Timezone { get; set; }
        /// <summary>
        /// city where airport placed
        /// </summary>
        public string ParentCity { get; set; }

        /// <summary>
        /// Object initialize through this constructor
        /// </summary>
        /// <param name="iata">airport iata code</param>
        /// <param name="name">airport name</param>
        /// <param name="coord">airport gps coordinates</param>
        /// <param name="timezone">timezone</param>
        /// <param name="city">city, where airport placed</param>
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
