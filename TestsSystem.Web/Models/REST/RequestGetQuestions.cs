namespace TestsSystem.Web.Models.REST
{
    public class RequestGetQuestions : RequestBase
    {
        public RequestGetQuestions(int themeId)
        {
            Endpoint = string.Format($"/questions/{themeId}");
        }
    }
}
