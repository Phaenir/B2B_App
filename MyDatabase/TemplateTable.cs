namespace MyDatabase
{
    /// <summary>
    /// Class that describes fields in table of database where saved information about xml templates of websites
    /// </summary>
    public class TemplateTable
    {
        /// <summary>
        /// the name of template
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// folder path in remote server where file saved
        /// </summary>
        public string FolderPath { get; set; }
        /// <summary>
        /// the name of file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">template name</param>
        /// <param name="folder">remote server path</param>
        /// <param name="file">file name</param>
        public TemplateTable(string name, string folder, string file)
        {
            Name = name;
            FolderPath = folder;
            FileName = file;
        }

        /// <summary>
        /// Constructor to initialize templates by name
        /// </summary>
        /// <param name="name">template name</param>
        public TemplateTable(string name)
        {
            Name = name;
        }
    }
}
