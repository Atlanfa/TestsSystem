using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Business.Contracts
{
    public interface IServQuestions
    {
        Task<AnswerBase> CreateQuestionAsync(DtoCreateQuestion dto);
        Task<AnswerBase> GetQuestionsAsync(int themeId);
        Task<AnswerBase> GetQuestionAsync(int questionId);
    }
}
