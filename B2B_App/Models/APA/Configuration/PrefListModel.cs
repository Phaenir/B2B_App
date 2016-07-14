using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MyDatabase;

namespace B2B_App.Models.APA.Configuration
{
    class PrefListModel
    {
        public static ObservableCollection<FlightPoint> FlightPoints { get; set; } = new ObservableCollection<FlightPoint>();

        public static void Init()
        {
            CommonConfigurationModel configuration = new CommonConfigurationModel();
            CommonConfig common = configuration.GetConfiguration();
            Database database = new Database(common.DatabaseHost, common.DatabaseUser, common.DatabasePassword, common.DatabaseName, (uint)common.DatabasePort);
            database.GetFlightPoints();
            FlightPoints = database.TravelPoints;
        }
        public List<string> GetFiles()
        {
            List<string> list = new List<string>();
            var t = Task.Run(async () =>
            {
                await RemoteSave.GetFilesNames(RemoteSave.State.ROUTE);
                list = RemoteSave.FileListOnRemote;
                
            });
            t.Wait();
            return list.Select(s => s.Substring(0, s.IndexOf('.'))).ToList();
        }
    }
    public enum FlightWay
    {
        DEPARTURE, ARRIVAL,
    }
}
