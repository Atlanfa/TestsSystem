using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseQuestion : ResponseBase
    {
        public DtoQuestion Question { get; set; }
    }
}
