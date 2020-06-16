using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoAnswers
    {
        Task<IEnumerable<Answer>> ToListAsync();
        Task<Answer> GetAnswerByIdAsync(int id);
        Task AddAnswerAsync(Answer answer);
        Task EditAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(Answer answer);
    }
}
