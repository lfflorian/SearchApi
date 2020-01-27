using SearchDataApi.Common.Classes;
using SearchDataApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SOAPDemoService;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace SearchDataApi.Services.SearchReferenceService
{
    class DemoService : ISearchReferenceService
    {
        public List<Request> ConsolidateRequestService(object dataResponse)
        {
            List<Request> Results = new List<Request>();

            var array = JArray.Parse((string)dataResponse);

            foreach (JObject obj in array.Children<JObject>())
            {
                Results.Add(new Request()
                {
                    From = "DemoSoap",
                    Content = obj
                });
            }

            return Results;
        }

        public string SearchInService(string inputText)
        {
            Task<PersonIdentification[]> task = GetPeople(inputText);
            task.Wait();
            var people = task.Result;
            return Newtonsoft.Json.JsonConvert.SerializeObject(people);
        }

        private async Task<PersonIdentification[]> GetPeople(string inputText)
        {
            SOAPDemoSoapClient SoapClient = new SOAPDemoSoapClient();
            return  await SoapClient.GetListByNameAsync(inputText).ConfigureAwait(false);
        }
    }
}
