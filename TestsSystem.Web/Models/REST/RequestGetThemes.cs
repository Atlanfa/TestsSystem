namespace TestsSystem.Web.Models.REST
{
    public class RequestGetThemes : RequestBase
    {
        public RequestGetThemes(int subjectId)
        {
            Endpoint = string.Format($"/themes/{subjectId}");
        }
    }
}
