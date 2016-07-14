using System;
using System.Collections.Generic;
using B2B_App.Models.APA.Configuration;

namespace B2B_App.Models.APA
{
    class MainPageModel
    {
        public void Start(List<object> websiteMembers, List<Route> flightLeg, DateTimeOffset? dep, DateTimeOffset? arr, string path)
        {
           SeleniumSearchForm search=new SeleniumSearchForm();
           search.Start(websiteMembers, flightLeg, dep,arr, path);
        }
    }
}
