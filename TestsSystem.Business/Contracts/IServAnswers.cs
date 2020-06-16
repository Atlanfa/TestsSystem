using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Business.Contracts
{
    public interface IServAnswers
    {
        Task<AnswerBase> AddIssuedAnswersAsync(List<DtoCreateAnswer> answers);
        Task<AnswerBase> GetAnswersAsync(string userMail);
        Task<AnswerBase> UpdateAnswerAsync(int answId, DtoAnswer answer);
    }
}
