namespace TestsSystem.Web.Models.REST
{
    public class RequestGetAppUsers : RequestBase
    {
        public RequestGetAppUsers(string role)
        {
            Endpoint = string.Format($"/appusers/{role}");
        }
    }
}
