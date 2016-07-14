namespace WebsiteCrawler.Database
{
    /// <summary>
    /// In this class we define variables where save data about html elements that help us make correctly the process of data filling in websites' web forms.
    /// </summary>
    public class TemplateSearchEngine
    {
        /// <summary>
        /// This object describes HTML elements that help us define Departure point in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags DeparturePoint { get; set; }
        /// <summary>
        /// This object describes HTML elements that help us define Arrival point in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags ArrivalPoint { get; set; }
        /// <summary>
        /// This object describes HTML elements that help us define Departure Date in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags DepartureDate { get; set; }
        /// <summary>
        /// This object describes HTML elements that help us define Arrival Date in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags ArrivalDate { get; set; }
        /// <summary>
        /// This object describes HTML elements that help us define Roundtrip element in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags Roundtrip { get; set; }
        /// <summary>
        /// This object describes HTML elements that help us define where Submit button placed in partner's and competitor's websites. The object consist of 3 string variables:
        /// a) Tag (HTML tag like "input", "div", "span" where we need get or put data
        /// b) Attr - tag's attribute that has unique text that helps correctly define required html tag.
        /// c) Name - the unique text that define exact element in DOM of HTML page.
        /// </summary>
        public HtmlTags ConfirmationButton { get; }

        /// <summary>
        /// Constructor where we initialize objects
        /// </summary>
        public TemplateSearchEngine()
        {
            DeparturePoint=new HtmlTags();
            ArrivalPoint=new HtmlTags();
            DepartureDate=new HtmlTags();
            ArrivalDate=new HtmlTags();
            Roundtrip=new HtmlTags();
            ConfirmationButton=new HtmlTags();
        }
        /// <summary>
        /// The method that copies values of objects from other. We need use such method as "deep link" method to make copy. Because other ways do not copy values of objects but links to the object. Thus, if we have changes in one of these objects data changed for all of them.
        /// </summary>
        /// <param name="searchEngine">This object variable describes object from which we make copy</param>
        public TemplateSearchEngine(TemplateSearchEngine searchEngine)
        {
            DeparturePoint = searchEngine.DeparturePoint;
            DepartureDate = searchEngine.DepartureDate;
            ArrivalPoint = searchEngine.ArrivalPoint;
            ArrivalDate = searchEngine.ArrivalDate;
            Roundtrip = searchEngine.Roundtrip;
            ConfirmationButton = searchEngine.ConfirmationButton;
        }

        /// <summary>
        /// This method compare initial object with target.
        /// </summary>
        /// <param name="searchEngine">Target object</param>
        /// 
        /// <returns>"True" if all object variables values are same, and "False" if one of the object variables values have any difference</returns>
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
