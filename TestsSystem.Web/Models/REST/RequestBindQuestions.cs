using Newtonsoft.Json;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Models.REST
{
    public class RequestBindQuestions : RequestBase
    {
        public RequestBindQuestions(List<FormBindQuestion> questions)
        {
            Endpoint = "/answers";
            ContentBody = new StringContent(
               JsonConvert.SerializeObject(questions));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
