using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using NameLib;
using FNameLib;

namespace FuncNameApp
{
    public static class FunctionTest
    {
        [FunctionName("Simpel")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            if (name == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");

            // Do the actual work here - expecting a long string with names passed in
            var names = new List<string>();
            names.Add(name);
                
            var list = NameParser.RunNames(names);
            string ret = "C# Simple list: ";
            foreach (var item in list)
            {
                ret = ret + $"{item.Name}, ";
            }
            ret = ret.Substring(0, ret.Length - 2);
            return req.CreateResponse(HttpStatusCode.OK, ret);
        }

        [FunctionName("Improved")]
        public static async Task<HttpResponseMessage> RunImproved([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            if (name == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");

            // Do the actual work here - expecting a long string with names passed in
            var names = new List<string>();
            names.Add(name);

            string ret = "C# Improved list: ";

            var list = ImprovedNameParser.RunNames(names);
            foreach (var item in list)
            {
                ret = ret + $"{item.Name}, ";
            }
            ret = ret.Substring(0, ret.Length - 2);
            return req.CreateResponse(HttpStatusCode.OK, ret);
        }

        [FunctionName("FSimpel")]
        public static async Task<HttpResponseMessage> FRun([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            if (name == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");

            // Do the actual work here - expecting a long string with names passed in
            var names = new List<string>();
            names.Add(name);

            var list = NameParsing.getMostPopularNames(names);
            string ret = "F# Simple list: ";
            foreach (var item in list)
            {
                ret = ret + $"{item}, ";
            }
            ret = ret.Substring(0, ret.Length - 2);
            return req.CreateResponse(HttpStatusCode.OK, ret);
        }

        [FunctionName("FImproved")]
        public static async Task<HttpResponseMessage> RunFImproved([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            if (name == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");

            // Do the actual work here - expecting a long string with names passed in
            var names = new List<string>();
            names.Add(name);

            string ret = "F# Improved list: ";

            var list = NameParsing.getMostPopularNamesRefactored(names);
            foreach (var item in list)
            {
                ret = ret + $"{item}, ";
            }
            ret = ret.Substring(0, ret.Length - 2);
            return req.CreateResponse(HttpStatusCode.OK, ret);
        }
    }
}
