using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoPrepods
    {
        Task<IEnumerable<Prepod>> ToListAsync();
        Task<Prepod> GetPrepodByEmailAsync(string email);
        Task<Prepod> GetPrepodByIdAsync(int id);
        Task AddPrepodAsync(Prepod prepod);
        Task EditPrepodAsync(Prepod prepod);
        Task DeletePrepodAsync(Prepod prepod);
    }
}
