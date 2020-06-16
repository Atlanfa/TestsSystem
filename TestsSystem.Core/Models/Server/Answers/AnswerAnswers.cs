using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerAnswers : AnswerSuccess
    {
        public List<DtoAnswer> Answers { get; set; }
    }
}
