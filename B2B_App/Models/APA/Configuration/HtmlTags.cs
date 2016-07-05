using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B_App.Models.APA.Configuration
{
    class HtmlTags
    {
        public string Tag { get; set; }
        public string Attr { get; set; }
        public string Name { get; set; }

        public HtmlTags(HtmlTags tags)
        {
            this.Tag = tags.Tag;
            this.Attr = tags.Attr;
            this.Name = tags.Name;
        }
        public bool IsSame(HtmlTags tags)
        {
            if (Tag!=tags.Tag)
            {
                return false;
            }
            if (Attr!=tags.Attr)
            {
                return false;
            }
            if (Name!=tags.Name)
            {
                return false;
            }
            return true;
        }
    }

}
