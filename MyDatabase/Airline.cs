namespace MyDatabase
{
    /// <summary>
    /// Class that describes fields in airline table in database
    /// </summary>
    public class Airline
    {
        /// <summary>
        /// IATA code of airline
        /// </summary>
        public string Iata { get; set; }
        /// <summary>
        /// The full name of airline
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor through which we initialize the object
        /// </summary>
        /// <param name="iata">airline IATA code</param>
        /// <param name="name">airline name</param>
        public Airline(string iata, string name)
        {
            Iata = iata;
            Name = name;
        }
    }
}
