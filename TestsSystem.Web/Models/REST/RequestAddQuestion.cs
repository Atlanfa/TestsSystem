using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Models.REST
{
    public class RequestAddQuestion : RequestBase
    {
        public RequestAddQuestion(FormAddQuestion formAddQuestion)
        {
            Endpoint = "/questions";
            ContentBody = new StringContent(
               JsonConvert.SerializeObject(formAddQuestion));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
