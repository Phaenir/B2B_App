namespace WebsiteCrawler.Database
{
    /// <summary>
    /// In this class we define variables where save data about html elements that help us make correctly the process of obtaining data from result page.
    /// </summary>
    public class TemplateResultEngine
    {
        /// <summary>
        /// Departure point
        /// </summary>
        public HtmlTags DeparturePoint { get; }
        /// <summary>
        /// Arrival Point
        /// </summary>
        public HtmlTags ArrivalPoint { get;}
        /// <summary>
        /// Date when passenger need to fly
        /// </summary>
        public HtmlTags DepartureDate { get; }
        /// <summary>
        /// Date when passenger landing in arrival point
        /// </summary>
        public HtmlTags ArrivalDate { get; }
        /// <summary>
        /// The number of airline's board
        /// </summary>
        public HtmlTags AirlineNumber { get; }
        /// <summary>
        /// the name of airline company that manage flight
        /// </summary>
        public HtmlTags AirlineName { get; }
        /// <summary>
        /// the value of airline's tariff
        /// </summary>
        public HtmlTags Tariff { get; }
        /// <summary>
        /// taxes
        /// </summary>
        public HtmlTags Tax { get; }
        /// <summary>
        /// agents and consolidators' charges (total)
        /// </summary>
        public HtmlTags Fee { get; }
        /// <summary>
        /// total price on the ticket = tariff+taxes+fee
        /// </summary>
        public HtmlTags Price { get; }
        /// <summary>
        /// time of flighting start
        /// </summary>
        public HtmlTags DepartureTime { get;  }
        /// <summary>
        /// time of flighting end
        /// </summary>
        public HtmlTags ArrivalTime { get;  }

        /// <summary>
        /// constructor where initialize with default values mentioned above variables.
        /// </summary>
        public TemplateResultEngine()
        {
            DeparturePoint=new HtmlTags();
            ArrivalPoint=new HtmlTags();
            DepartureDate=new HtmlTags();
            ArrivalDate=new HtmlTags();
            AirlineName=new HtmlTags();
            AirlineNumber=new HtmlTags();
            DepartureTime=new HtmlTags();
            ArrivalTime=new HtmlTags();
            Tariff=new HtmlTags();
            Tax=new HtmlTags();
            Fee=new HtmlTags();
            Price=new HtmlTags();
        }
    }
}
