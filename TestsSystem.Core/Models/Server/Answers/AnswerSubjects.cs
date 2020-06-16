using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerSubjects : AnswerSuccess
    {
        public List<DtoSubject> Subjects { get; set; }
    }
}
