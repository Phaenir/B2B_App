namespace B2B_App.Models.APA.Configuration
{
    class TemplateResultEngine
    {
        public HtmlTags DeparturePoint { get; set; }
        public HtmlTags ArrivalPoint { get; set; }
        public HtmlTags DepartureDate { get; set; }
        public HtmlTags ArrivalDate { get; set; }
        public HtmlTags AirlineNumber { get; set; }
        public HtmlTags AirlineName { get; set; }
        public HtmlTags Tariff { get; set; }
        public HtmlTags Tax { get; set; }
        public HtmlTags Fee { get; set; }
        public HtmlTags Price { get; set; }
        public HtmlTags DepartureTime { get; set; }
        public HtmlTags ArrivalTime { get; set; }

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
