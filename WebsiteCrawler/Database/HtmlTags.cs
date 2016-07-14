namespace WebsiteCrawler.Database
{
    /// <summary>
    /// Class that describes 3 main identificators on the site to define in sure the exact web element in hmtl DOM with interested us information
    /// </summary>
    public class HtmlTags
    {
        private string _tag;
        /// <summary>
        /// html tag. If value is null, than set as default empty space
        /// </summary>
        public string Tag { get { return _tag; } set {
            _tag = value ?? " ";
        }
        }

        private string _attr;
        /// <summary>
        /// tag's attribute. If value is null, than set as default empty space
        /// </summary>
        public string Attr { get { return _attr; } set { _attr = value ?? " "; } }
        private string _name;
        /// <summary>
        /// the value of attribute in tag. If value is null, than set as default empty space
        /// </summary>
        public string Name { get { return _name; } set { _name = value ?? " "; } }

        /// <summary>
        /// Constructor that initialize the object
        /// </summary>
        public HtmlTags()
        {
            Tag = null;
            Attr = null;
            Name = null;
        }
        /// <summary>
        /// copy of HtmlTag object in "deep link" mode (not as relation between objects but copy values of object fields in other
        /// </summary>
        /// <param name="tags">Object that need to copy</param>
        public HtmlTags(HtmlTags tags)
        {
            Tag = tags.Tag;
            Attr = tags.Attr;
            Name = tags.Name;
        }
    }
}
