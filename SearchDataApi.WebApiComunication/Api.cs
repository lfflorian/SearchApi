using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.InteropServices;

namespace SearchDataApi.WebApiComunication
{
    public static class Api
    {
        /// <summary>
        /// Method used for make a simple request to api rest
        /// </summary>
        /// <param name="url">Api rest adress to comunicate</param>
        /// <param name="data">Data from the body request</param>
        /// <param name="headers">Data for the header request</param>
        /// <param name="method">Web Method to use for the request</param>
        /// <param name="contentType">(OPTIONAL) Content type for the request</param>
        /// <returns>Returns the HttpResponseMessage that contain the value of the response</returns>
        public static HttpResponseMessage SendRequest(string url, string data, Dictionary<string, object> headers, Method method, [Optional] string contentType)
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = new HttpMethod(method.ToString()),
                RequestUri = new Uri(url)
            };

            if ( data != null)
                request.Content = new StringContent(data);

            headers.ToList().ForEach(e => {
                request.Headers.Add(e.Key, e.Value.ToString());
            });

            if (contentType != null)
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

            return client.SendAsync(request).Result;
        }

        /// <summary>
        /// Method used for get the status and data from api responses
        /// </summary>
        /// <param name="response">Response obtained from the request of a Api Rest adress</param>
        /// <returns></returns>
        public static Response GetResponseInformation(HttpResponseMessage response)
        {
            return new Response(response.StatusCode, response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Select the method to use for the request
        /// </summary>
        public enum Method
        {
            POST = 1,
            GET = 2,
            PUT = 3,
            DELETE = 4,
            PATCH = 5
        }

        public struct Response
        {
            public HttpStatusCode StatusCode;
            public string Data;

            public Response(HttpStatusCode status, string data)
            {
                StatusCode = status;
                Data = data;
            }
        }
    }
}