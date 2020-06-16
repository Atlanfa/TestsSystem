using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerThemes : AnswerSuccess
    {
        public List<DtoTheme> Themes { get; set; }
    }
}
