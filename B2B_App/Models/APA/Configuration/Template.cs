namespace B2B_App.Models.APA.Configuration
{
    class Template
    {
        public TemplateSearchEngine SearchEngine { get; set; }
        public TemplateResultEngine ResultEngine { get; set; }
        public TemplateAdditionalInfo AdditionalInfo { get; set; }
        public TemplateCommonInfo CommonInfo { get; set; }

        public Template()
        {
            SearchEngine=new TemplateSearchEngine();
            ResultEngine=new TemplateResultEngine();
            AdditionalInfo=new TemplateAdditionalInfo();
            CommonInfo=new TemplateCommonInfo();
        }
    }
}
