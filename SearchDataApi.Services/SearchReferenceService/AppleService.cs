using SearchDataApi.Common.Classes;
using SearchDataApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using SearchDataApi.WebApiComunication;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SearchDataApi.Services.SearchReferenceService
{
    class AppleService : ISearchReferenceService
    {
        public string Url { get; set; }

        public AppleService()
        {
            Url = "https://itunes.apple.com/search?term=";
        }

        public List<Request> ConsolidateRequestService(object dataResponse)
        {
            List<Request> Results = new List<Request>();

            var jsonObject = JObject.Parse((string)dataResponse);

            var array = JArray.Parse(jsonObject["results"].ToString());

            foreach (JObject obj in array.Children<JObject>())
            {
                Results.Add(new Request()
                {
                    From = "Apple",
                    Content = obj
                });
            }

            return Results;
        }

        public string SearchInService(string inputText)
        {
            var urlRequest = $"{Url}{inputText}";
            var response = Api.SendRequest(urlRequest, null, new Dictionary<string, object>(), Api.Method.GET);
            var information = Api.GetResponseInformation(response);
            if (information.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return information.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
