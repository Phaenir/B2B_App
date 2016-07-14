namespace B2B_App.Models.APA.Configuration
{
    class HtmlTags
    {
        private string _tag;
        public string Tag { get { return _tag; } set {
            _tag = value ?? " ";
        }
        }

        private string _attr;
        public string Attr { get { return _attr; } set { _attr = value ?? " "; } }
        private string _name;
        public string Name { get { return _name; } set { _name = value ?? " "; } }

        public HtmlTags()
        {
            Tag = null;
            Attr = null;
            Name = null;
        }      
    }
}
