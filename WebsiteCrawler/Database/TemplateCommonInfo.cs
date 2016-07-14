namespace WebsiteCrawler.Database
{
    /// <summary>
    /// In this class we manage data with xml file where website template saved in part of common information
    /// </summary>
    public class TemplateCommonInfo
    {
        /// <summary>
        /// The name of site
        /// </summary>
        public string WebsiteName { get; set; }
        /// <summary>
        /// the exact url of the site
        /// </summary>
        public string WebsiteUrl { get; set; }
    }
}
