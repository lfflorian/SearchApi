using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchDataApi.Services;
using SearchDataApi.Common.Interfaces;

namespace SearchDataApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // GET api/values
        [HttpGet("{content}")]
        public ActionResult<string> Get(string content)
        {
            var ISearchReferenceServicesImplementation = ReferenceServices.GgetAllTypes();

            ISearchReferenceServicesImplementation.ToList().ForEach(reference => {
                ISearchReferenceService SearhReference = (ISearchReferenceService)Activator.CreateInstance(reference);
                var resultado = SearhReference.SearchInService(content);
            });
            
            return "value";
        }
    }
}