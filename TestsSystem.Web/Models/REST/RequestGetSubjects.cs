namespace TestsSystem.Web.Models.REST
{
    public class RequestGetSubjects : RequestBase
    {
        public RequestGetSubjects(string prepodMail)
        {
            Endpoint = string.Format($"/subjects/{prepodMail}");
        }
    }
}
