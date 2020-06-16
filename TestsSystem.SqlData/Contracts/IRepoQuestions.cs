using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoQuestions
    {
        Task<IEnumerable<Question>> ToListAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task AddQuestionAsync(Question question);
        Task EditQuestionAsync(Question question);
        Task DeleteQuestionAsync(Question question);
    }
}
