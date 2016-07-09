﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.Views.APA;
using MyDatabase;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace B2B_App.ViewModels.APA
{
    class APrefListViewModel:ViewModelBase
    {
        public static APrefListViewModel _viewModel=new APrefListViewModel();
       // IDictionary<string,object> state = Template10.Common.BootStrapper.Current.SessionState;

        private static List<FlightPoint> _travelPoints=new List<FlightPoint>(); 
        public List<FlightPoint> TravelPoints { get { return _travelPoints; } set { Set(ref _travelPoints, value); } } 

        public static List<Route> _routes=new List<Route>();
        public List<Route> Routes { get { return _routes; } set { Set(ref _routes, value); } }
        
        private static List<string> _fileList=new List<string>();
        public List<string> FileList { get { return _fileList; } set { Set(ref _fileList, value); } }
        readonly PrefListModel model=new PrefListModel();

        public APrefListViewModel()
        {
           // var t = Task.Run(async () => { await Init(); });
            Init();
        }
        private void Init()
        {
            //state.Clear();
            _travelPoints = PrefListModel.FlightPoints.ToList();
            TravelPoints = _travelPoints;
            FileList = model.GetFiles();
            FileList.Sort();
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

        public async void AddRouteToList()
        {
            _viewModel.Routes = _routes;
       /*     if (state.ContainsKey("routes"))
            {
                state["routes"] = Routes;
            }
            else
            {
                state.Add("routes", Routes);
            }
            var t = Task.Run(async () =>
            {
                await OnNavigatedToAsync(typeof(PrefListPage), NavigationMode.Refresh, state);

            });
            t.Wait();
           // await OnNavigatedToAsync(typeof(PrefListPage), NavigationMode.Refresh, state);
           */

            NavigationService.Navigate(typeof(PrefListPage), Routes);
            await Task.CompletedTask;
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
         //   if (suspensionState.Any())
         //   {
         //       Routes =(List<Route>)suspensionState["routes"];
         //   }
           // PrefListPage page = (PrefListPage) parameter;
          //  page.InitializeComponent();
            
            
            await Task.CompletedTask;
        }
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
           /* if (state.ContainsKey("routes"))
            {
                state["routes"] = Routes;
            }
            else
            {
                state.Add("routes", Routes);
            }
            if (suspending)
            {
                suspensionState["routes"] = Routes;
            }*/
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
        public async void SaveRoutesInFile(string text)
        {
            string file= Routes.Aggregate<Route, string>(null, (current, route) => current + (route.FlightLeg + Environment.NewLine));
            if (text.Length==0||text==""||file.Length==0||file=="")
            {
                return;
            }
            await RemoteSave.SaveContentToFtp(file, text, RemoteSave.State.ROUTE);
            _viewModel.Routes = null;
            FileList = model.GetFiles();
          /*  var t = Task.Run(async () =>
            {
                await OnNavigatedToAsync(typeof(MainPage), NavigationMode.Refresh, state);

            });
            t.Wait();*/
           // await OnNavigatedToAsync(typeof (MainPage), NavigationMode.Refresh, state);
           //NavigationService.Navigate(typeof(MainPage));
        }
    }
}
