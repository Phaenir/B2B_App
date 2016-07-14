namespace MyDatabase
{
    /// <summary>
    /// Class, that describes fields in city table in database
    /// </summary>
    public class City
    {

        /// <summary>
        /// IATA code of city
        /// </summary>
        public string Iata { get; set; }
        /// <summary>
        /// Full name of city
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// GPS coordinates of city
        /// </summary>
        public string Coordinates { get; set; }
        /// <summary>
        /// timezone
        /// </summary>
        public string Timezone { get; set; }
        /// <summary>
        /// country of the city
        /// </summary>
        public string ParentCountry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iata">city airport code</param>
        /// <param name="name">name of city</param>
        /// <param name="coord">GPS coordinates of city</param>
        /// <param name="timezone">timezone</param>
        /// <param name="country">country</param>
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
