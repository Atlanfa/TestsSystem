using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;

using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Models.REST
{
    public class RequesCreateTheme : RequestBase
    {
        public RequesCreateTheme(FormAddTheme formAddTheme)
        {
            Endpoint = "/themes";
            ContentBody = new StringContent(
                JsonConvert.SerializeObject(formAddTheme));
            ContentBody.Headers.ContentType
                = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}
