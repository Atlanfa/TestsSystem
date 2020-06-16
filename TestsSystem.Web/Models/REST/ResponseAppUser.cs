using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseAppUser : ResponseBase
    {
        public DtoAppUser AppUser { get; set; }
    }
}
