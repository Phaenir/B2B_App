using System.Threading.Tasks;

namespace B2B_App.Models.APA.Configuration
{
    class TemplateConfigModel
    {      
        public async Task<Template> GetConfiguration(string fileName)
        {
            Template template = new Template();
            string xml = await RemoteSave.GetContentFromFtp(fileName, RemoteSave.State.TEMPLATE);
            var website = WebsiteTemplate.Deserialize(xml);
            
            template.CommonInfo.WebsiteName = website.Name;
            template.CommonInfo.WebsiteUrl = website.URL;

            template.SearchEngine.DeparturePoint.Tag = website.SearchEngine.DeparturePoint.Tag;
            template.SearchEngine.DeparturePoint.Attr = website.SearchEngine.DeparturePoint.Attr;
            template.SearchEngine.DeparturePoint.Name = website.SearchEngine.DeparturePoint.Name;
            template.SearchEngine.DepartureDate.Tag = website.SearchEngine.DepartureDate.Tag;
            template.SearchEngine.DepartureDate.Attr = website.SearchEngine.DepartureDate.Attr;
            template.SearchEngine.DepartureDate.Name = website.SearchEngine.DepartureDate.Name;
            template.SearchEngine.ArrivalPoint.Tag = website.SearchEngine.ArrivalPoint.Tag;
            template.SearchEngine.ArrivalPoint.Attr = website.SearchEngine.ArrivalPoint.Attr;
            template.SearchEngine.ArrivalPoint.Name = website.SearchEngine.ArrivalPoint.Name;
            template.SearchEngine.ArrivalDate.Tag = website.SearchEngine.ArrivalDate.Tag;
            template.SearchEngine.ArrivalDate.Attr = website.SearchEngine.ArrivalDate.Attr;
            template.SearchEngine.ArrivalDate.Name = website.SearchEngine.ArrivalDate.Name;
            template.SearchEngine.Roundtrip.Tag = website.SearchEngine.Roundtrip.Tag;
            template.SearchEngine.Roundtrip.Attr = website.SearchEngine.Roundtrip.Attr;
            template.SearchEngine.Roundtrip.Name = website.SearchEngine.Roundtrip.Name;
            template.SearchEngine.ConfirmationButton.Tag = website.SearchEngine.ConfirmationButton.Tag;
            template.SearchEngine.ConfirmationButton.Attr = website.SearchEngine.ConfirmationButton.Attr;
            template.SearchEngine.ConfirmationButton.Name = website.SearchEngine.ConfirmationButton.Name;

            template.ResultEngine.DeparturePoint.Tag = website.ResultEngine.DeparturePoint.Tag;
            template.ResultEngine.DeparturePoint.Attr = website.ResultEngine.DeparturePoint.Attr;
            template.ResultEngine.DeparturePoint.Name = website.ResultEngine.DeparturePoint.Name;
            template.ResultEngine.DepartureDate.Tag = website.ResultEngine.DepartureDate.Tag;
            template.ResultEngine.DepartureDate.Attr = website.ResultEngine.DepartureDate.Attr;
            template.ResultEngine.DepartureDate.Name = website.ResultEngine.DepartureDate.Name;
            template.ResultEngine.DepartureTime.Tag = website.ResultEngine.DepartureTime.Tag;
            template.ResultEngine.DepartureTime.Attr = website.ResultEngine.DepartureTime.Attr;
            template.ResultEngine.DepartureTime.Name = website.ResultEngine.DepartureTime.Name;
            template.ResultEngine.ArrivalPoint.Tag = website.ResultEngine.ArrivalPoint.Tag;
            template.ResultEngine.ArrivalPoint.Attr = website.ResultEngine.ArrivalPoint.Attr;
            template.ResultEngine.ArrivalPoint.Name = website.ResultEngine.ArrivalPoint.Name;
            template.ResultEngine.ArrivalDate.Tag = website.ResultEngine.ArrivalDate.Tag;
            template.ResultEngine.ArrivalDate.Attr = website.ResultEngine.ArrivalDate.Attr;
            template.ResultEngine.ArrivalDate.Name = website.ResultEngine.ArrivalDate.Name;
            template.ResultEngine.ArrivalTime.Tag = website.ResultEngine.ArrivalTime.Tag;
            template.ResultEngine.ArrivalTime.Attr = website.ResultEngine.ArrivalTime.Attr;
            template.ResultEngine.ArrivalTime.Name = website.ResultEngine.ArrivalTime.Name;
            //
            template.ResultEngine.AirlineName.Tag = website.ResultEngine.AirlineName.Tag;
            template.ResultEngine.AirlineName.Attr = website.ResultEngine.AirlineName.Attr;
            template.ResultEngine.AirlineName.Name = website.ResultEngine.AirlineName.Name;
            template.ResultEngine.AirlineNumber.Tag = website.ResultEngine.AirlineNumber.Tag;
            template.ResultEngine.AirlineNumber.Attr = website.ResultEngine.AirlineNumber.Attr;
            template.ResultEngine.AirlineNumber.Name = website.ResultEngine.AirlineNumber.Name;
            template.ResultEngine.Tariff.Tag = website.ResultEngine.Tariff.Tag;
            template.ResultEngine.Tariff.Attr = website.ResultEngine.Tariff.Attr;
            template.ResultEngine.Tariff.Name = website.ResultEngine.Tariff.Name;
            template.ResultEngine.Tax.Tag = website.ResultEngine.Tax.Tag;
            template.ResultEngine.Tax.Attr = website.ResultEngine.Tax.Attr;
            template.ResultEngine.Tax.Name = website.ResultEngine.Tax.Name;
            template.ResultEngine.Fee.Tag = website.ResultEngine.Fee.Tag;
            template.ResultEngine.Fee.Attr = website.ResultEngine.Fee.Attr;
            template.ResultEngine.Fee.Name = website.ResultEngine.Fee.Name;
            template.ResultEngine.Price.Tag = website.ResultEngine.Price.Tag;
            template.ResultEngine.Price.Attr = website.ResultEngine.Price.Attr;
            template.ResultEngine.Price.Name = website.ResultEngine.Price.Name;

            template.AdditionalInfo.ListAllowed.Tag = website.AdditionalInfo.ListAllowed.Tag;
            template.AdditionalInfo.ListAllowed.Attr = website.AdditionalInfo.ListAllowed.Attr;
            template.AdditionalInfo.ListAllowed.Name = website.AdditionalInfo.ListAllowed.Name;
            template.AdditionalInfo.Back.Tag = website.AdditionalInfo.Back.Tag;
            template.AdditionalInfo.Back.Attr = website.AdditionalInfo.Back.Attr;
            template.AdditionalInfo.Back.Name = website.AdditionalInfo.Back.Name;
            template.AdditionalInfo.Detail.Tag = website.AdditionalInfo.Detail.Tag;
            template.AdditionalInfo.Detail.Attr = website.AdditionalInfo.Detail.Attr;
            template.AdditionalInfo.Detail.Name = website.AdditionalInfo.Detail.Name;
            template.AdditionalInfo.ExactlyAirline.Tag = website.AdditionalInfo.ExactlyAirline.Tag;
            template.AdditionalInfo.ExactlyAirline.Attr = website.AdditionalInfo.ExactlyAirline.Attr;
            template.AdditionalInfo.ExactlyAirline.Name = website.AdditionalInfo.ExactlyAirline.Name;
            template.AdditionalInfo.OnlyDirect.Tag = website.AdditionalInfo.OnlyDirect.Tag;
            template.AdditionalInfo.OnlyDirect.Attr = website.AdditionalInfo.OnlyDirect.Attr;
            template.AdditionalInfo.OnlyDirect.Name = website.AdditionalInfo.OnlyDirect.Name;
            return template;
        }

        public async Task SetConfiguration(Template website)
        {
            WebsiteTemplate template = new WebsiteTemplate
            {
                Name = website.CommonInfo.WebsiteName,
                URL = website.CommonInfo.WebsiteUrl
            };


            template.SearchEngine.DeparturePoint.Tag = website.SearchEngine.DeparturePoint.Tag;
            template.SearchEngine.DeparturePoint.Attr = website.SearchEngine.DeparturePoint.Attr;
            template.SearchEngine.DeparturePoint.Name = website.SearchEngine.DeparturePoint.Name;
            template.SearchEngine.DepartureDate.Tag = website.SearchEngine.DepartureDate.Tag;
            template.SearchEngine.DepartureDate.Attr = website.SearchEngine.DepartureDate.Attr;
            template.SearchEngine.DepartureDate.Name = website.SearchEngine.DepartureDate.Name;
            template.SearchEngine.ArrivalPoint.Tag = website.SearchEngine.ArrivalPoint.Tag;
            template.SearchEngine.ArrivalPoint.Attr = website.SearchEngine.ArrivalPoint.Attr;
            template.SearchEngine.ArrivalPoint.Name = website.SearchEngine.ArrivalPoint.Name;
            template.SearchEngine.ArrivalDate.Tag = website.SearchEngine.ArrivalDate.Tag;
            template.SearchEngine.ArrivalDate.Attr = website.SearchEngine.ArrivalDate.Attr;
            template.SearchEngine.ArrivalDate.Name = website.SearchEngine.ArrivalDate.Name;
            template.SearchEngine.Roundtrip.Tag = website.SearchEngine.Roundtrip.Tag;
            template.SearchEngine.Roundtrip.Attr = website.SearchEngine.Roundtrip.Attr;
            template.SearchEngine.Roundtrip.Name = website.SearchEngine.Roundtrip.Name;
            template.SearchEngine.ConfirmationButton.Tag = website.SearchEngine.ConfirmationButton.Tag;
            template.SearchEngine.ConfirmationButton.Attr = website.SearchEngine.ConfirmationButton.Attr;
            template.SearchEngine.ConfirmationButton.Name = website.SearchEngine.ConfirmationButton.Name;

            template.ResultEngine.DeparturePoint.Tag = website.ResultEngine.DeparturePoint.Tag;
            template.ResultEngine.DeparturePoint.Attr = website.ResultEngine.DeparturePoint.Attr;
            template.ResultEngine.DeparturePoint.Name = website.ResultEngine.DeparturePoint.Name;
            template.ResultEngine.DepartureDate.Tag = website.ResultEngine.DepartureDate.Tag;
            template.ResultEngine.DepartureDate.Attr = website.ResultEngine.DepartureDate.Attr;
            template.ResultEngine.DepartureDate.Name = website.ResultEngine.DepartureDate.Name;
            template.ResultEngine.DepartureTime.Tag = website.ResultEngine.DepartureTime.Tag;
            template.ResultEngine.DepartureTime.Attr = website.ResultEngine.DepartureTime.Attr;
            template.ResultEngine.DepartureTime.Name = website.ResultEngine.DepartureTime.Name;
            template.ResultEngine.ArrivalPoint.Tag = website.ResultEngine.ArrivalPoint.Tag;
            template.ResultEngine.ArrivalPoint.Attr = website.ResultEngine.ArrivalPoint.Attr;
            template.ResultEngine.ArrivalPoint.Name = website.ResultEngine.ArrivalPoint.Name;
            template.ResultEngine.ArrivalDate.Tag = website.ResultEngine.ArrivalDate.Tag;
            template.ResultEngine.ArrivalDate.Attr = website.ResultEngine.ArrivalDate.Attr;
            template.ResultEngine.ArrivalDate.Name = website.ResultEngine.ArrivalDate.Name;
            template.ResultEngine.ArrivalTime.Tag = website.ResultEngine.ArrivalTime.Tag;
            template.ResultEngine.ArrivalTime.Attr = website.ResultEngine.ArrivalTime.Attr;
            template.ResultEngine.ArrivalTime.Name = website.ResultEngine.ArrivalTime.Name;
            //
            template.ResultEngine.AirlineName.Tag = website.ResultEngine.AirlineName.Tag;
            template.ResultEngine.AirlineName.Attr = website.ResultEngine.AirlineName.Attr;
            template.ResultEngine.AirlineName.Name = website.ResultEngine.AirlineName.Name;
            template.ResultEngine.AirlineNumber.Tag = website.ResultEngine.AirlineNumber.Tag;
            template.ResultEngine.AirlineNumber.Attr = website.ResultEngine.AirlineNumber.Attr;
            template.ResultEngine.AirlineNumber.Name = website.ResultEngine.AirlineNumber.Name;
            template.ResultEngine.Tariff.Tag = website.ResultEngine.Tariff.Tag;
            template.ResultEngine.Tariff.Attr = website.ResultEngine.Tariff.Attr;
            template.ResultEngine.Tariff.Name = website.ResultEngine.Tariff.Name;
            template.ResultEngine.Tax.Tag = website.ResultEngine.Tax.Tag;
            template.ResultEngine.Tax.Attr = website.ResultEngine.Tax.Attr;
            template.ResultEngine.Tax.Name = website.ResultEngine.Tax.Name;
            template.ResultEngine.Fee.Tag = website.ResultEngine.Fee.Tag;
            template.ResultEngine.Fee.Attr = website.ResultEngine.Fee.Attr;
            template.ResultEngine.Fee.Name = website.ResultEngine.Fee.Name;
            template.ResultEngine.Price.Tag = website.ResultEngine.Price.Tag;
            template.ResultEngine.Price.Attr = website.ResultEngine.Price.Attr;
            template.ResultEngine.Price.Name = website.ResultEngine.Price.Name;

            template.AdditionalInfo.ListAllowed.Tag = website.AdditionalInfo.ListAllowed.Tag;
            template.AdditionalInfo.ListAllowed.Attr = website.AdditionalInfo.ListAllowed.Attr;
            template.AdditionalInfo.ListAllowed.Name = website.AdditionalInfo.ListAllowed.Name;
            template.AdditionalInfo.Back.Tag = website.AdditionalInfo.Back.Tag;
            template.AdditionalInfo.Back.Attr = website.AdditionalInfo.Back.Attr;
            template.AdditionalInfo.Back.Name = website.AdditionalInfo.Back.Name;
            template.AdditionalInfo.Detail.Tag = website.AdditionalInfo.Detail.Tag;
            template.AdditionalInfo.Detail.Attr = website.AdditionalInfo.Detail.Attr;
            template.AdditionalInfo.Detail.Name = website.AdditionalInfo.Detail.Name;
            template.AdditionalInfo.ExactlyAirline.Tag = website.AdditionalInfo.ExactlyAirline.Tag;
            template.AdditionalInfo.ExactlyAirline.Attr = website.AdditionalInfo.ExactlyAirline.Attr;
            template.AdditionalInfo.ExactlyAirline.Name = website.AdditionalInfo.ExactlyAirline.Name;
            template.AdditionalInfo.OnlyDirect.Tag = website.AdditionalInfo.OnlyDirect.Tag;
            template.AdditionalInfo.OnlyDirect.Attr = website.AdditionalInfo.OnlyDirect.Attr;
            template.AdditionalInfo.OnlyDirect.Name = website.AdditionalInfo.OnlyDirect.Name;

            string xml = template.Serialize();
            await RemoteSave.SaveContentToFtp(xml, website.CommonInfo.WebsiteName, RemoteSave.State.TEMPLATE);
        }
    }
}