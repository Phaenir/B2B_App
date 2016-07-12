namespace WebsiteCrawler.Database
{
    public class TemplateSearchEngine
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
        public TemplateSearchEngine(TemplateSearchEngine searchEngine)
        {
            DeparturePoint = searchEngine.DeparturePoint;
            DepartureDate = searchEngine.DepartureDate;
            ArrivalPoint = searchEngine.ArrivalPoint;
            ArrivalDate = searchEngine.ArrivalDate;
            Roundtrip = searchEngine.Roundtrip;
            ConfirmationButton = searchEngine.ConfirmationButton;
        }

        public bool IsSame(TemplateSearchEngine searchEngine)
        {
            if (DeparturePoint != searchEngine.DeparturePoint)
                return false;
            if (DepartureDate != searchEngine.DepartureDate)
                return false;
            if (ArrivalPoint != searchEngine.ArrivalPoint)
                return false;
            if (ArrivalDate != searchEngine.ArrivalDate)
                return false;
            if (Roundtrip != searchEngine.Roundtrip)
                return false;
            if (ConfirmationButton != searchEngine.ConfirmationButton)
                return false;
            return true;
        }
    }
}
