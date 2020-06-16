using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Models.REST
{
    public class RequestCreateAppUser : RequestBase
    {
        public RequestCreateAppUser(FormRegisterUser registerUser)
        {
            Endpoint = string.Format($"/appusers");
            ContentBody = new StringContent(
                JsonConvert.SerializeObject(registerUser));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
