namespace B2B_App.Models.APA.Configuration
{
    class TemplateAdditionalInfo
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
    }
}
