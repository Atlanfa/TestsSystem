using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Models.REST
{
    public class RequestGetAppUser : RequestBase
    {
        public RequestGetAppUser(FormLoginUser loginUser)
        {
            Endpoint = string.Format($"/appusers?role={loginUser.Role}&email={loginUser.Mail}");
        }
    }
}
