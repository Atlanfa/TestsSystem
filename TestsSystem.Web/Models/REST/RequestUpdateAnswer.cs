using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class RequestUpdateAnswer : RequestBase
    {
        public RequestUpdateAnswer(DtoAnswer answer)
        {
            Endpoint = string.Format($"/answers/{answer.Id}");
            ContentBody = new StringContent(
                JsonConvert.SerializeObject(answer));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
