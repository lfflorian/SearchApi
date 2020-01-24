using SearchDataApi.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchDataApi.Services
{
    public static class ReferenceServices
    {
        public static IEnumerable<Type> GgetAllTypes()
        {
            return  AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ISearchReferenceService).IsAssignableFrom(p) && !p.IsInterface);
        }
    }
}
