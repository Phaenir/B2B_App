using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace B2B_App.ViewModels.APA
{
    class AMainPageViewModel:ViewModelBase
    {
        public AMainPageViewModel() { }
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



    }
}
