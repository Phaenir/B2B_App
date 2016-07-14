namespace WebsiteCrawler.Database
{
    /// <summary>
    /// Class that describes fields in service_class table in database. In this table we save data about all possible service class offered by airline, like Econom, Business, First, Basic, Student and etc.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Id of service at the table
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of service
        /// </summary>
        public string ServiceClassName { get; set; }
    }
}
