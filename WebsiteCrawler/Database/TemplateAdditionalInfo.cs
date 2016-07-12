namespace WebsiteCrawler.Database
{
    public class TemplateAdditionalInfo
    {
        public HtmlTags ListAllowed { get; set; }
        public HtmlTags Detail { get; set; }
        public HtmlTags Back { get; set; }
        public HtmlTags ExactlyAirline { get; set; }
        public HtmlTags OnlyDirect { get; set; }

        public TemplateAdditionalInfo()
        {
            ListAllowed=new HtmlTags();
            Detail=new HtmlTags();
            Back=new HtmlTags();
            ExactlyAirline=new HtmlTags();
            OnlyDirect=new HtmlTags();
        }
        public TemplateAdditionalInfo(TemplateAdditionalInfo additionalInfo)
        {
            ListAllowed = additionalInfo.ListAllowed;
            Detail = additionalInfo.Detail;
            Back = additionalInfo.Back;
            ExactlyAirline = additionalInfo.ExactlyAirline;
            OnlyDirect = additionalInfo.OnlyDirect;
        }

        public bool IsSame(TemplateAdditionalInfo additionalInfo)
        {
            if (ListAllowed != additionalInfo.ListAllowed)
                return false;
            if (Detail != additionalInfo.Detail)
                return false;
            if (Back != additionalInfo.Back)
                return false;
            if (ExactlyAirline != additionalInfo.ExactlyAirline)
                return false;
            if (OnlyDirect != additionalInfo.OnlyDirect)
                return false;
            return true;
        }
    }
}
