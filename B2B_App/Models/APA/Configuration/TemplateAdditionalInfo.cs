using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateAdditionalInfo
    {
        public HtmlTags ListAllowed { get; set; }
        public HtmlTags Detail { get; set; }
        public HtmlTags Back { get; set; }
        public HtmlTags ExactlyAirline { get; set; }
        public HtmlTags OnlyDirect { get; set; }

        public TemplateAdditionalInfo() { }
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
