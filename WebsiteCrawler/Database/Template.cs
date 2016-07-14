namespace WebsiteCrawler.Database
{
    /// <summary>
    /// In this class we combine all data about website to make possible it to parse
    /// </summary>
    public class Template
    {
        /// <summary>
        /// Part that required to fill booking form on website
        /// </summary>
        public TemplateSearchEngine SearchEngine { get; }
        /// <summary>
        /// Part that required to get data from result page of website
        /// </summary>
        public TemplateResultEngine ResultEngine { get; }
        /// <summary>
        /// Part that specify and make more detailed information from result page
        /// </summary>
        public TemplateAdditionalInfo AdditionalInfo { get; }
        /// <summary>
        /// Part that store common information to get access on website
        /// </summary>
        public TemplateCommonInfo CommonInfo { get; }

        /// <summary>
        /// In this constructor we initialize variables
        /// </summary>
        public Template()
        {
            SearchEngine=new TemplateSearchEngine();
            ResultEngine=new TemplateResultEngine();
            AdditionalInfo=new TemplateAdditionalInfo();
            CommonInfo=new TemplateCommonInfo();
        }
    }
}
