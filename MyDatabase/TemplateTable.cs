using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace MyDatabase
{
    public class TemplateTable
    {
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public string FileName { get; set; }

        public TemplateTable(string name, string folder, string file)
        {
            Name = name;
            FolderPath = folder;
            FileName = file;
        }

        public TemplateTable(string name)
        {
            Name = name;
        }
    }
}
