using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerQuestions : AnswerSuccess
    {
        public List<DtoQuestion> Questions { get; set; }
    }
}
