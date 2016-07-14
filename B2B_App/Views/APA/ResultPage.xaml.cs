using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace B2B_App.Views.APA
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            this.InitializeComponent();
            NavigationCacheMode=NavigationCacheMode.Enabled;
            StartDate.MinYear=DateTimeOffset.Now;
            EndDate.MinYear=DateTimeOffset.Now;
        }
    }
}
