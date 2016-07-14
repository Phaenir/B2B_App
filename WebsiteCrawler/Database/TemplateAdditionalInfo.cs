namespace WebsiteCrawler.Database
{
    /// <summary>
    /// Class that realize data from xml template where saved preferences to manage additional functionality to obtain detailed information on website
    /// </summary>
    public class TemplateAdditionalInfo
    {
        /// <summary>
        /// If in result page we have possibility to change view in table form
        /// </summary>
        public HtmlTags ListAllowed { get; }
        /// <summary>
        /// if we have in result page results as blocks with pop-up additional information
        /// </summary>
        public HtmlTags Detail { get; }
        /// <summary>
        /// if detail information in result page opens in new browser tab or page and thus we need returns back
        /// </summary>
        public HtmlTags Back { get; }
        /// <summary>
        /// if we need point specific airline in search
        /// </summary>
        public HtmlTags ExactlyAirline { get; }
        /// <summary>
        /// if we require only direct routes without any stop overs
        /// </summary>
        public HtmlTags OnlyDirect { get; }

        /// <summary>
        /// Constructor where we initialize object variables
        /// </summary>
        public TemplateAdditionalInfo()
        {
            ListAllowed=new HtmlTags();
            Detail=new HtmlTags();
            Back=new HtmlTags();
            ExactlyAirline=new HtmlTags();
            OnlyDirect=new HtmlTags();
        }
    }
}
