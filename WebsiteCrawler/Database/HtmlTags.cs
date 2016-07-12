namespace WebsiteCrawler.Database
{
    public class HtmlTags
    {
        private string _tag;
        public string Tag { get { return _tag; } set {
            _tag = value ?? " ";
        }
        }

        private string _attr;
        public string Attr { get { return _attr; } set { _attr = value ?? " "; } }
        private string _name;
        public string Name { get { return _name; } set { _name = value ?? "n/a "; } }

        public HtmlTags()
        {
            Tag = null;
            Attr = null;
            Name = null;
        }
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
            return Name == tags.Name;
        }
    }

}
