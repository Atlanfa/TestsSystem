using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.REST
{
    public class ResponseAnswers : ResponseBase
    {
        public List<DtoAnswer> Answers { get; set; }
    }
}
