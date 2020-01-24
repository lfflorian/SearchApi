using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchDataApi.Services;
using SearchDataApi.Common.Interfaces;
using SearchDataApi.Common.Classes;


namespace SearchDataApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // GET api/values
        [HttpGet("{content}")]
        public ActionResult<List<Request>> Get(string content)
        {
            var ISearchReferenceServicesImplementation = ReferenceServices.GgetAllTypes();
            List<Request> results = new List<Request>();
            ISearchReferenceServicesImplementation.ToList().ForEach(reference => {
                ISearchReferenceService SearhReference = (ISearchReferenceService)Activator.CreateInstance(reference);
                var resultado = SearhReference.SearchInService(content);
                results = SearhReference.ConsolidateRequestService(resultado);
            });
            
            return results;
        }
    }
}