using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.ViewManagement;
using B2B_App.Models.APA.Configuration;
using MyDatabase;

namespace B2B_App.Models.APA
{
    class SeleniumSearchForm
    {    
        internal async void Start(List<object> websiteMembers, List<Route> flightLeg, DateTimeOffset? dep, DateTimeOffset? arr, string path)
        {
            string conf = websiteMembers.Cast<TemplateTable>().Aggregate<TemplateTable, string>(null, (current, member) => current + (member.Name + ";"));
            conf += Environment.NewLine;
            conf = flightLeg.Aggregate(conf, (current, route) => current + (route.Departure + route.Delimeter + route.Arrival + ";"));
            conf += Environment.NewLine;
            if (dep != null) if (arr != null) conf += $"{dep:yyyy-MM-dd}" +";"+$"{arr:yyyy-MM-dd}" + Environment.NewLine;
            conf += path + Environment.NewLine;
            var t = Task.Run(async () =>
            {
                await RemoteSave.SaveContentToFtp(conf, "conf", RemoteSave.State.INTERMEDIATE);
            });
            t.Wait();

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file =await folder.GetFileAsync("WebsiteCrawler.exe");
            bool success=false;
            var n = Task.Run(async () =>
            {
                LauncherOptions options = new LauncherOptions
                {
                    TreatAsUntrusted = false,
                    DesiredRemainingView = ViewSizePreference.UseMinimum, DisplayApplicationPicker = true, 
                };
                success= await Launcher.LaunchFileAsync(file,options);
            });
            n.Wait();                     
        }
    }
}
