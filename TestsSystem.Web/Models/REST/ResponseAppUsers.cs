using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseAppUsers : ResponseBase
    {
        public List<DtoAppUser> AppUsers { get; set; }
    }
}
