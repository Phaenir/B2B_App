namespace MyDatabase
{
    /// <summary>
    /// Class that describes fields in country table in database
    /// </summary>
    public class Country
    {
        /// <summary>
        /// IATA code of country
        /// </summary>
        public string Iata { get; set; }
        /// <summary>
        /// The full name of country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor through which we initialize the object
        /// </summary>
        /// <param name="iata">country IATA code</param>
        /// <param name="name">country name</param>
        public Country(string iata, string name)
        {
            Iata = iata;
            Name = name;
        }

    }
}
