using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Template(Template template)
        {
            this.SearchEngine = template.SearchEngine;
            this.ResultEngine = template.ResultEngine;
            this.AdditionalInfo = template.AdditionalInfo;
            this.CommonInfo = template.CommonInfo;
        }
        public bool IsSame(Template start)
        {
            if (SearchEngine == start.SearchEngine && ResultEngine == start.ResultEngine && AdditionalInfo == start.AdditionalInfo&&CommonInfo==start.CommonInfo)
            {
                return true;
            }
            return false;
        }
    }
}
