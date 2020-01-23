using System;
using System.Collections.Generic;
using System.Text;

namespace SearchDataApi.Common.Interfaces
{
    public interface ISearchReferenceService
    {
        string SearchInService(string inputText);
        string ConsolidateRequestService(object Format, string json);
    }
}
