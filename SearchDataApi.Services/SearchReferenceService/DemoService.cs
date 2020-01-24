using SearchDataApi.Common.Classes;
using SearchDataApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SOAPDemoService;
using System.Threading.Tasks;

namespace SearchDataApi.Services.SearchReferenceService
{
    class DemoService : ISearchReferenceService
    {
        public List<Request> ConsolidateRequestService(object dataResponse)
        {
            throw new NotImplementedException();
        }

        public string SearchInService(string inputText)
        {
            SOAPDemoService.SOAPDemoSoapClient SoapClient = new SOAPDemoSoapClient();
            var persons = GetPersons(inputText);
            //person.
            return "";
        }

        private async Task GetPersons(string inputText)
        {
            SOAPDemoService.SOAPDemoSoapClient SoapClient = new SOAPDemoSoapClient();
            var persons =  await SoapClient.GetByNameAsync(inputText).ConfigureAwait(false);
        }
    }
}
