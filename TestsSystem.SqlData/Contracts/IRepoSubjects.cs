using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoSubjects
    {
        Task<IEnumerable<Subject>> ToListAsync();
        Task<Subject> GetSubjectsByIdAsync(int id);
        Task AddSubjectnAsync(Subject subject);
        Task EditSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(Subject subject);
    }
}
