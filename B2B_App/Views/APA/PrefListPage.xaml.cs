using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.ViewModels.APA;
using MyDatabase;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace B2B_App.Views.APA
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PrefListPage : Page
    {

        private Route _route;
        public PrefListPage()
        {
            this.InitializeComponent();            
        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var matchingDestinations =APrefListViewModel.GetMathingDestinations(sender.Text);
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
        
        private void AutoSuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var travel = args.SelectedItem as FlightPoint;
            Debug.Assert(travel != null, "travel != null");
            sender.Text = String.Format("{0} ({1} - {2})", travel.Iata, travel.Name, travel.CountryCode);

        }

        private void SelectDestination(FlightPoint flight, FlightWay way)
        {
            if (flight != null)
            {
                if (_route==null)
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
                    APrefListViewModel._viewModel.Routes.Add(_route);
                }
            }
        }

        private void DepartureSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox_OnQuerySubmitted(sender,args,FlightWay.DEPARTURE);
        }

        private void ArrivalSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox_OnQuerySubmitted(sender,args,FlightWay.ARRIVAL);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            APrefListViewModel._viewModel.SaveRoutesInFile(SaveFileBox.Text);
        }
    }
}
