namespace TestsSystem.Web.Models.REST
{
    public class RequestGetAnswers : RequestBase
    {
        public RequestGetAnswers(string mail)
        {
            Endpoint = string.Format($"/answers/{mail}");
        }
    }
}
