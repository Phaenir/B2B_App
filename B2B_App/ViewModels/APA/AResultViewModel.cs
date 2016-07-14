using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.Views.APA;
using MyDatabase;

namespace B2B_App.ViewModels.APA
{
    class AResultViewModel:ViewModelBase
    {
        DateTime _startDate;
        DateTime _endDate;
        public DateTime StartDate {
            get { return _startDate; }
            set { Set(ref _startDate,value); } }
        public DateTime EndDate {
            get { return _endDate; }
            set { Set(ref _endDate,value); } }

        public AResultViewModel()
        {
            StartDate=DateTime.Today;
            EndDate=DateTime.Today;
            
        }

        private static List<ResultView> _result = new List<ResultView>();
        public List<ResultView> Result { get { return _result; }
            private set { Set(ref _result, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                Result = (List<ResultView>) suspensionState[nameof(Result)];
                StartDate = (DateTime) suspensionState[nameof(StartDate)];
                EndDate = (DateTime) suspensionState[nameof(EndDate)];
                NavigationService.Frame.BackStack.Clear();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(EndDate)] = EndDate;
                suspensionState[nameof(StartDate)] = StartDate;
                suspensionState[nameof(Result)] = Result;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void ShowResultButton()
        {
            CommonConfigurationModel configuration = new CommonConfigurationModel();
            CommonConfig common = configuration.GetConfiguration();
            Database database = new Database(common.DatabaseHost, common.DatabaseUser, common.DatabasePassword, common.DatabaseName, (uint)common.DatabasePort);
            database.SetResultView(StartDate, EndDate);
            database.GetResultView();
            Result = database.ResultViews.ToList();
            database.DropResultView();
            NavigationService.Navigate(typeof(ResultPage), Result);
        }

        public void DateChanged()
        {
            EndDate = StartDate;
        }
    }
    
}
