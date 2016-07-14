using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace B2B_App.ViewModels.APA
{
    class ACommonConfigModelView:ViewModelBase
    {
        private string _agencyName;
        public string AgencyName { get { return _agencyName; } set { Set(ref _agencyName, value); } }
        private string _agencyNumber;
        public string AgencyNumber { get { return _agencyNumber; } set { Set(ref _agencyNumber, value); } }
        private string _agencyPassword;
        public string AgencyPassword { get { return _agencyPassword; } set { Set(ref _agencyPassword, value); } }
        private string _agencySalespoint;
        public string AgencySalespoint { get { return _agencySalespoint; } set { Set(ref _agencySalespoint, value); } }

        private string _databaseHost;
        public string DatabaseHost { get { return _databaseHost; } set { Set(ref _databaseHost, value); } }
        private string _databaseRemoteHost;
        public string DatabaseRemoteHost { get { return _databaseRemoteHost; } set { Set(ref _databaseRemoteHost, value); } }
        private string _databasePassword;
        public string DatabasePassword { get { return _databasePassword; } set { Set(ref _databasePassword, value); } }
        private string _databaseUser;
        public string DatabaseUser { get { return _databaseUser; } set { Set(ref _databaseUser, value); } }
        private string _databaseName;
        public string DatabaseName { get { return _databaseName; } set { Set(ref _databaseName, value); } }
        private int _databasePort;
        public int DatabasePort { get { return _databasePort; } set { Set(ref _databasePort, value); } }

        private int _formLimit;
        public int FormLimit { get { return _formLimit; } set { Set(ref _formLimit, value); } }
        private int _pageLimit;
        public int PageLimit { get { return _pageLimit; } set { Set(ref _pageLimit, value); } }
        private int _searchLimit;
        public int SearchLimit { get { return _searchLimit; } set { Set(ref _searchLimit, value); } }

        private CommonConfig _startConfig;
        private CommonConfigurationModel _configuration;

        public ACommonConfigModelView()
        {
            _startConfig=new CommonConfig();
            _configuration=new CommonConfigurationModel();
            _startConfig = _configuration.GetConfiguration();
            AgencyName = _startConfig.AgencyName;
            AgencyNumber = _startConfig.AgencyNumber;
            AgencyPassword = _startConfig.AgencyPassword;
            AgencySalespoint = _startConfig.AgencySalespoint;
            DatabasePassword = _startConfig.DatabasePassword;
            DatabaseHost = _startConfig.DatabaseHost;
            DatabaseName = _startConfig.DatabaseName;
            DatabaseRemoteHost = _startConfig.DatabaseRemote;
            DatabaseUser = _startConfig.DatabaseUser;
            DatabasePort = _startConfig.DatabasePort;
            FormLimit = _startConfig.FormLimit;
            PageLimit = _startConfig.PageLimit;
            SearchLimit = _startConfig.SearchLimit;
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
               
            }
            await Task.CompletedTask;

        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoPreferableRoutesPage() => NavigationService.Navigate(typeof(Views.APA.PrefListPage), 0);
        public void GotoMakeWebsiteTemplatePage() => NavigationService.Navigate(typeof(Views.APA.TemplateConfigPage), 1);

        public void SaveNewCommonConfig()
        {
            _startConfig.AgencyName= AgencyName;
            _startConfig.AgencyNumber= AgencyNumber;
            _startConfig.AgencyPassword= AgencyPassword;
            _startConfig.AgencySalespoint= AgencySalespoint;
            _startConfig.DatabasePassword =DatabasePassword ;
            _startConfig.DatabaseHost =DatabaseHost ;
            _startConfig.DatabaseName= DatabaseName  ;
            _startConfig.DatabaseRemote= DatabaseRemoteHost  ;
            _startConfig.DatabaseUser =DatabaseUser  ;
            _startConfig.DatabasePort =DatabasePort  ;
            _startConfig.FormLimit =FormLimit  ;
            _startConfig.PageLimit =PageLimit  ;
            _startConfig.SearchLimit =SearchLimit  ;
            _configuration.SetConfiguration(config:_startConfig);
            NavigationService.Navigate(typeof(Views.APA.MainPage));
        }
    }
}
