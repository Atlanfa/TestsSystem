using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoRootUsers
    {
        Task<IEnumerable<RootUser>> ToListAsync();
        Task<RootUser> GetAppUserByEmailAsync(string email);
        Task<RootUser> GetAppUserByIdAsync(int id);
        Task AddAppUserAsync(RootUser rootUser);
        Task EditAppUserAsync(RootUser rootUser);
        Task DeleteAppUserAsync(RootUser rootUser);
    }
}
