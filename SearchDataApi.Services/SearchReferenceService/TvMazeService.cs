using SearchDataApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            return urlRequest;
        }
    }
}
