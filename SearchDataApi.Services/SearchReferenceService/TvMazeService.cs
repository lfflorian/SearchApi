using System;
using System.Collections.Generic;
using System.Text;
using SearchDataApi.Common.Interfaces;
using SearchDataApi.WebApiComunication;

namespace SearchDataApi.Services.SearchReferenceService
{
    public class TvMazeService : ISearchReferenceService
    {
        public string Url { get; set; }

        public TvMazeService()
        {
            Url = "http://api.tvmaze.com/search/shows?q=";
        }

        public string ConsolidateRequestService(object Format, string json)
        {
            throw new NotImplementedException();
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
