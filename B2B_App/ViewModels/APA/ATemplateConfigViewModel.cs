using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.Views.APA;
using MyDatabase;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Template10.Services.NavigationService;

namespace B2B_App.ViewModels.APA
{
    class ATemplateConfigViewModel:ViewModelBase
    {
        private static TemplateTable _clickedItem;

        private static Template _template=new Template();
        public Template Template { get { return _template; } set { Set(ref _template, value); } }

        private ObservableCollection<TemplateTable> _observableCollection=new ObservableCollection<TemplateTable>();
        public ObservableCollection<TemplateTable> TemplateTables {get { return _observableCollection; }
            set { Set(ref _observableCollection, value);} }

        public ATemplateConfigViewModel()
        {
            Init();
        }

        private void Init()
        {
            TemplateTables = null;
            CommonConfigurationModel configuration=new CommonConfigurationModel();
            CommonConfig common=configuration.GetConfiguration();
            Database database=new Database(common.DatabaseHost,common.DatabaseUser,common.DatabasePassword,common.DatabaseName,(uint)common.DatabasePort);
            database.GetTemplates();
            TemplateTables = database.TemplateTables;
            Template = _template;
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Init();
            NavigationService.Frame.BackStack.Clear();

            await Task.CompletedTask;
        }      

        public async void SaveTemplate()
        {
            CommonConfigurationModel configuration = new CommonConfigurationModel();
            CommonConfig common = configuration.GetConfiguration();
            Database database = new Database(common.DatabaseHost, common.DatabaseUser, common.DatabasePassword, common.DatabaseName, (uint)common.DatabasePort);
            TemplateConfigModel configModel = new TemplateConfigModel();
            if (string.IsNullOrEmpty(_template.CommonInfo.WebsiteName) ||
                string.IsNullOrEmpty(_template.CommonInfo.WebsiteUrl)) return;
            await configModel.SetConfiguration(_template);
            try
            {
                database.InsertTemplatesToDatabase(Template.CommonInfo.WebsiteName, "/Templates/",
                Template.CommonInfo.WebsiteName + ".xml");
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
            }                     
        }
        public async void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            _clickedItem = (TemplateTable)e.ClickedItem;
            if (string.IsNullOrEmpty(_clickedItem.Name)) return;
            TemplateConfigModel configModel=new TemplateConfigModel();
            try
            {
                _template = await configModel.GetConfiguration(_clickedItem.Name);
                Template = _template;
            }
            catch (Exception exception)
            {
                Debug.Assert(true, exception.Message);
            }

            this.NavigationService.Navigate(typeof(TemplateConfigPage),this.Template);                
        }
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
            }
            //NavigationService.Frame.BackStack.Clear();

            TemplateTables = null;
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            TemplateTables = null;
            await Task.CompletedTask;
        }
    }
}
