using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class RequestCreateSubject : RequestBase
    {
        public RequestCreateSubject(DtoCreateSubject dto)
        {
            Endpoint = "/subjects";
            ContentBody = new StringContent(
               JsonConvert.SerializeObject(dto));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
