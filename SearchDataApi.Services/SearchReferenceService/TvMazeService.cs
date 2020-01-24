using System;
using System.Collections.Generic;
using System.Text;
using SearchDataApi.Common.Interfaces;
using SearchDataApi.WebApiComunication;
using Newtonsoft.Json;
using SearchDataApi.Services;
using Newtonsoft.Json.Linq;
using SearchDataApi.Common.Classes;

namespace SearchDataApi.Services.SearchReferenceService
{
    public class TvMazeService : ISearchReferenceService
    {
        public string Url { get; set; }

        public TvMazeService()
        {
            Url = "http://api.tvmaze.com/search/shows?q=";
        }

        public List<Request> ConsolidateRequestService(object dataResponse)
        {
            List<Request> Results = new List<Request>();

            var array = JArray.Parse((string)dataResponse);

            foreach (JObject obj in array.Children<JObject>())
            {
                var o = obj["show"];
                Results.Add(new Request()
                {
                    From = "TvMaze",
                    Content = obj["show"]
                });
            }

            return Results;
        }

        public string SearchInService(string inputText)
        {
            var urlRequest = $"{Url}{inputText}";
            var response = Api.SendRequest(urlRequest, null, new Dictionary<string, object>(), Api.Method.GET);
            var information = Api.GetResponseInformation(response);
            if (information.StatusCode == System.Net.HttpStatusCode.OK )
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
