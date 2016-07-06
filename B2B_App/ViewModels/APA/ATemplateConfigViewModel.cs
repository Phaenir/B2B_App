using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B_App.Models.APA.Configuration;
using MyDatabase;
using Template10.Mvvm;

namespace B2B_App.ViewModels.APA
{
    class ATemplateConfigViewModel:ViewModelBase
    {
        public TemplateConfigModel ConfigModel;
        public Template Template;
        public Template BackupTemplate;
        public TemplateTable Table;
        public Database Database;
        private ObservableCollection<TemplateTable> _observableCollection; 
        public ObservableCollection<TemplateTable> TemplateTables {get { return _observableCollection; } set
        {
            Set(ref _observableCollection, value);
        } }

        //public string AgencyPassword { get { return _agencyPassword; } set { Set(ref _agencyPassword, value); } }

        public ATemplateConfigViewModel()
        {
            ConfigModel=new TemplateConfigModel();
            Template=new Template();
            Table=new TemplateTable();
            Database=new Database();
            TemplateTables = Database.TemplateTables;
        }


    }
}
