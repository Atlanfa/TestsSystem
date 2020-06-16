using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseSubjects : ResponseBase
    {
        public List<DtoSubject> Subjects { get; set; }
    }
}
