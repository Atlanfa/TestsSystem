using TestsSystem.Core.DTO;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerQuestion : AnswerSuccess
    {
        public DtoQuestion Question { get; set; }
    }
}
