using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.Views.APA;
using MyDatabase;
using Template10.Mvvm;
using Template10.Behaviors;
using System.Windows.Input;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace B2B_App.ViewModels.APA
{
    class ATemplateConfigViewModel:ViewModelBase
    {
        static ATemplateConfigViewModel _viewModel=new ATemplateConfigViewModel();
        public TemplateConfigModel ConfigModel;
        public static Template _template=new Template();
        public Template Template { get { return _template; } set { Set(ref _template, value); } }
        private Database _database;
        private ObservableCollection<TemplateTable> _observableCollection; 
        public ObservableCollection<TemplateTable> TemplateTables {get { return _observableCollection; } set { Set(ref _observableCollection, value);} }
        private string _selectedValue;
        public string SelectedValue { get { return _selectedValue; } set { Set(ref _selectedValue, value); } }

        public ATemplateConfigViewModel()
        {
            Template=_template;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            _database = new Database();
            _database.GetTemplates();
            TemplateTables = _database.TemplateTables;
            //Template = _template;
            await Task.CompletedTask;
        }
        public async static Task LoadTemplate(TemplateTable itemTable)
        {
            if (!string.IsNullOrEmpty(itemTable.Name))
            {
                TemplateConfigModel configModel = new TemplateConfigModel();
                _template=await configModel.GetConfiguration(itemTable.Name);
                _viewModel.Template = _template;
            }
            else
            {
                _template=new Template();
            }
        }

        public void Init()
        {
            Template = Template==null ? new Template() : _template;
        }

        public async void SaveTemplate()
        {
            ConfigModel = new TemplateConfigModel();
            if (!string.IsNullOrEmpty(_template.CommonInfo.WebsiteName) && !string.IsNullOrEmpty(_template.CommonInfo.WebsiteUrl))
            {
                await ConfigModel.SetConfiguration(_template);
                _database.InsertTemplatesToDatabase(Template.CommonInfo.WebsiteName, "/Templates/",
                    Template.CommonInfo.WebsiteName + ".xml");
            }
        }
    }
}
