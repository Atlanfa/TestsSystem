using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseQuestions : ResponseBase
    {
        public List<DtoQuestion> Questions { get; set; }
    }
}
