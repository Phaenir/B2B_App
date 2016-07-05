using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateCommonInfo
    {
        public HtmlTags WebsiteName { get; set; }
        public HtmlTags WebsiteUrl { get; set; }
        public TemplateCommonInfo() { }
        public TemplateCommonInfo(TemplateCommonInfo commonInfo)
        {
            WebsiteName = commonInfo.WebsiteName;
            WebsiteUrl = commonInfo.WebsiteUrl;
        }

        public bool IsSame(TemplateCommonInfo commonInfo)
        {
            if (WebsiteName != commonInfo.WebsiteName)
                return false;
            if (WebsiteUrl != commonInfo.WebsiteUrl)
                return false;
            return true;
        }
    }
}
