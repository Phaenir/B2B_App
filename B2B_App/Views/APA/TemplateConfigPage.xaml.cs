using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using B2B_App.Models.APA.Configuration;
using B2B_App.ViewModels.APA;
using MyDatabase;
using static B2B_App.ViewModels.APA.ATemplateConfigViewModel;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace B2B_App.Views.APA
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TemplateConfigPage : Page
    {
        public static MyDatabase.TemplateTable ClickedItem;
        private static ATemplateConfigViewModel view=new ATemplateConfigViewModel();
        public TemplateConfigPage()
        {
            this.InitializeComponent();
        }

        private async void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ClickedItem = (TemplateTable)e.ClickedItem;
            if (!string.IsNullOrEmpty(ClickedItem.Name))
            {
                TemplateConfigModel configModel = new TemplateConfigModel();
                ATemplateConfigViewModel._template = await configModel.GetConfiguration(ClickedItem.Name);
                view.Init();
                //ATemplateConfigViewModel.Template = _template;
            }
            //await LoadTemplate(ClickedItem);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ClickedItem!=null)
            {
                TemplateConfigModel configModel = new TemplateConfigModel();
                ATemplateConfigViewModel._template = await configModel.GetConfiguration(ClickedItem.Name);
                view.Init();
                //ATemplateConfigViewModel.Template = _template;
            }
            view.Init();
        }
    }
}
