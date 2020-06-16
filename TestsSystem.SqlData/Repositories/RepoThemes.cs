using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoThemes : IRepoThemes
    {
        private readonly TestsSystemContext _context;

        public RepoThemes(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddThemesnAsync(Theme theme)
        {
            await _context.Themes.AddAsync(theme);
            await _context.SaveChangesAsync();
        }

        public Task DeleteThemesAsync(Theme theme)
        {
            _context.Themes.Remove(theme);
            return _context.SaveChangesAsync();
        }

        public Task EditThemesAsync(Theme theme)
        {
            _context.Themes.Update(theme);
            return _context.SaveChangesAsync();
        }

        public async Task<Theme> GetThemesByIdAsync(int id)
            => await _context.Themes.AsNoTracking().Include(t
                => t.Questions).Include(t => t.Subject)
                    .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Theme>> ToListAsync()
            => await _context.Themes.AsNoTracking().Include(t
                => t.Questions).Include(t => t.Subject).ToListAsync();
    }
}
