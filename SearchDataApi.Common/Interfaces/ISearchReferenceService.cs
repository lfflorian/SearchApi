using SearchDataApi.Common.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchDataApi.Common.Interfaces
{
    public interface ISearchReferenceService
    {
        string SearchInService(string inputText);
        List<Request> ConsolidateRequestService(object dataResponse);
    }
}
