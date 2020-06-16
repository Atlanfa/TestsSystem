namespace TestsSystem.Web.Models.REST
{
    public class RequestGetQuestion : RequestBase
    {
        public RequestGetQuestion(int questionId)
        {
            Endpoint = string.Format($"/questions?questId={questionId}");
        }
    }
}
