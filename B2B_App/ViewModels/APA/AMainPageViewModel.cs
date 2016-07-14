using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA;
using B2B_App.Models.APA.Configuration;
using GalaSoft.MvvmLight.Command;
using MyDatabase;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace B2B_App.ViewModels.APA
{
    class AMainPageViewModel:ViewModelBase
    {
        private static AMainPageViewModel _viewModel=new AMainPageViewModel();
        private List<TemplateTable> _website=new List<TemplateTable>();
        public List<TemplateTable> Websites { get { return _website; }set { Set(ref _website, value); } }

        protected List<object> WebsiteMembers=new List<object>();

        private static List<string> _fileList = new List<string>();
        public List<string> FileList { get { return _fileList; } set { Set(ref _fileList, value); } }
        readonly PrefListModel model = new PrefListModel();


        private RelayCommand<IList<object>> _addMembersToEvent;
        public RelayCommand<IList<object>> AddMembersToEvent
        {
            get
            {
                return _addMembersToEvent
                       ?? (_addMembersToEvent = new RelayCommand<IList<object>>(
                           selectedMembers =>
                           {
                               WebsiteMembers=selectedMembers.ToList();
                           }));
            }
        }

        List<string> _routesList=new List<string>();

        public AMainPageViewModel()
        {
            Init();
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

        public void GotoCommonConfigPage() => NavigationService.Navigate(typeof(Views.APA.CommonConfigPage), 0);
        public void GotoResultPage() => NavigationService.Navigate(typeof(Views.APA.ResultPage), 1);
        CommonConfigurationModel _configuration = new CommonConfigurationModel();
        private CommonConfig _common;
        private void Init()
        {
            Websites = null;

            try
            {
                _common = _configuration.GetConfiguration();
                Database database = new Database(_common.DatabaseHost, _common.DatabaseUser, _common.DatabasePassword, _common.DatabaseName, (uint)_common.DatabasePort);
                database.GetTemplates();
                _website = database.TemplateTables.ToList();
            }
            catch (Exception exception)
            {
                Debug.Assert(true,exception.Message);
            }
            
            Websites = _website;
            FileList = model.GetFiles();
            FileList.Sort();
            _travelPoints = PrefListModel.FlightPoints.ToList();
            TravelPoints = _travelPoints;
            _isRoundtripPushed = false;
        }

        public async void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = (ListView) sender;
            string str = list.SelectedItem?.ToString();
            string file =await RemoteSave.GetContentFromFtp(str, RemoteSave.State.ROUTE);
            var arr=file.Split(Environment.NewLine.ToCharArray());
            _routesList = arr.Where(s => !String.IsNullOrEmpty(s)).ToList();
            _routeListOnPage.Footer = "";
            _routeListOnPage.ItemsSource = _routesList;            
        }

        ListView _routeListOnPage=new ListView();
        private static List<FlightPoint> _travelPoints = new List<FlightPoint>();
        public List<FlightPoint> TravelPoints { get { return _travelPoints; } set { Set(ref _travelPoints, value); } }

        public void FrameworkElement_OnLoading(FrameworkElement sender, object args)
        {
            _routeListOnPage = (ListView) sender;
            _routeListOnPage.Footer = "Waiting..";
        }

        public void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var matchingDestinations = GetMathingDestinations(sender.Text);
                sender.ItemsSource = matchingDestinations.ToList();
            }
        }

        private void AutoSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args, FlightWay way)
        {
            if (args.ChosenSuggestion != null)
            {
                SelectDestination(args.ChosenSuggestion as FlightPoint, way);
            }
        }

        public void AutoSuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var travel = args.SelectedItem as FlightPoint;
            Debug.Assert(travel != null, "travel != null");
            sender.Text = String.Format("{0} ({1})", travel.Iata, travel.CityName);

        }

        Route _route=new Route();
        readonly List<Route> _flightLeg=new List<Route>();

        private void SelectDestination(FlightPoint flight, FlightWay way)
        {
            if (flight != null)
            {
                if (_route == null)
                {
                    _route = new Route();
                }
                switch (way)
                {
                    case FlightWay.DEPARTURE:
                        _route.Departure = flight.Iata;
                        break;
                    case FlightWay.ARRIVAL:
                        _route.Arrival = flight.Iata;
                        break;
                }
                if (_route.FormRoute())
                {
                    _flightLeg.Add(_route);
                }
            }
        }

        public void DepartureSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox_OnQuerySubmitted(sender, args, FlightWay.DEPARTURE);
        }

        public void ArrivalSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox_OnQuerySubmitted(sender, args, FlightWay.ARRIVAL);
        }

        public static IEnumerable<FlightPoint> GetMathingDestinations(string query)
        {
            return
               _viewModel.TravelPoints.Where(
                    c =>
                        c.CityCode.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1 ||
                        c.Iata.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1 ||
                        c.CityName.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1)
                    .OrderByDescending(c => c.CityCode.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
                    .ThenByDescending(c => c.Iata.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
                    .ThenByDescending(c => c.CityName.StartsWith(query, StringComparison.CurrentCultureIgnoreCase));
        }

        private CalendarDatePicker _departureDatePicker;
        private CalendarDatePicker _arrivalDatePicker;
        private static bool _isRoundtripPushed;
        public void DepartureElement_OnLoading(FrameworkElement sender, object args)
        {
            _departureDatePicker = (CalendarDatePicker)sender;
            _departureDatePicker.IsTodayHighlighted = true;
            _departureDatePicker.MinDate = DateTimeOffset.Now;

        }

        public void ArrivalElement_OnLoading(FrameworkElement sender, object args)
        {
            _arrivalDatePicker = (CalendarDatePicker) sender;
            _arrivalDatePicker.IsTodayHighlighted = true;
            _arrivalDatePicker.MinDate=DateTimeOffset.Now;
            _arrivalDatePicker.IsEnabled = false;
        }

        public void CalendarDatePicker_OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            _departureDatePicker = (CalendarDatePicker) sender;
            Debug.Assert(_departureDatePicker.Date != null, "_departureDatePicker.Date != null");
            _arrivalDatePicker.MinDate = (DateTimeOffset) _departureDatePicker.Date;
        }
        private Button _roundtripButton;
        public void RoundtripButton_OnClick(object sender, RoutedEventArgs e)
        {
            var brush=new ImageBrush();
            
            _roundtripButton = (Button) sender;
            if (!_isRoundtripPushed)
            {
                brush.ImageSource=new BitmapImage(new Uri("ms-appx:///Assets/oneway.png"));
                _roundtripButton.Background = brush;
                _arrivalDatePicker.IsEnabled = false;
            }
            else
            {
                brush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/roundtrip.png"));
                _roundtripButton.Background = brush;
                _arrivalDatePicker.IsEnabled = true;
            }
            _isRoundtripPushed = !_isRoundtripPushed;
        }
        public void SearchButton()
        {
            if (WebsiteMembers.Count==0)
            {
                return;
            }
            if (WebsiteMembers.Count>_common.PageLimit)
            {
                WebsiteMembers.RemoveRange(_common.PageLimit,WebsiteMembers.Count-1);
            }
            if (_flightLeg.Count==0&&_routesList.Count==0)
            {
                return;
            }
            if (_routesList.Count!=0)
            {
                if (_flightLeg.Count!=0)
                {
                    _flightLeg.RemoveAt(0);
                }
                foreach (string s in _routesList)
                {
                    Route route = new Route
                    {
                        Departure = s.Substring(0, 3),
                        Arrival = s.Substring(4, 3)
                    };
                    _flightLeg.Add(route);
                }
            }
            DateTimeOffset? dep = _departureDatePicker.Date;
            DateTimeOffset? arr = null;
            if (!_isRoundtripPushed)
            {
                arr = _arrivalDatePicker.Date;
            }
            MainPageModel model=new MainPageModel();

            model.Start(WebsiteMembers, _flightLeg, dep, arr,_configuration.Path);           
        }

    }
}
