using System.Collections.Generic;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerAppUsers : AnswerSuccess
    {
        public IEnumerable<AppUser> AppUsers { get; set; }
    }
}
