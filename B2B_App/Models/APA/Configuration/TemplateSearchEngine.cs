namespace B2B_App.Models.APA.Configuration
{
    class TemplateSearchEngine
    {
        public HtmlTags DeparturePoint { get; set; }
        public HtmlTags ArrivalPoint { get; set; }
        public HtmlTags DepartureDate { get; set; }
        public HtmlTags ArrivalDate { get; set; }
        public HtmlTags Roundtrip { get; set; }
        public HtmlTags ConfirmationButton { get; set; }

        public TemplateSearchEngine()
        {
            DeparturePoint=new HtmlTags();
            ArrivalPoint=new HtmlTags();
            DepartureDate=new HtmlTags();
            ArrivalDate=new HtmlTags();
            Roundtrip=new HtmlTags();
            ConfirmationButton=new HtmlTags();
        }
    }
}
