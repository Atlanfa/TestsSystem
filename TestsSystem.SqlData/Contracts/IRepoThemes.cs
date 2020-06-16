using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoThemes
    {
        Task<IEnumerable<Theme>> ToListAsync();
        Task<Theme> GetThemesByIdAsync(int id);
        Task AddThemesnAsync(Theme theme);
        Task EditThemesAsync(Theme theme);
        Task DeleteThemesAsync(Theme theme);
    }
}
