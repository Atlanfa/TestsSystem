using System.Collections.Generic;
using System.Net.Http;

namespace TestsSystem.Web.Models.REST
{
    public abstract class RequestBase
    {
        public string Endpoint { get; protected set; }
        public Dictionary<string, string> Headers { get; set; }
        public HttpContent ContentBody { get; protected set; }
    }
}
