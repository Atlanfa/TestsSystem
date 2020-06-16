using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoRootUsers : IRepoRootUsers
    {
        private readonly TestsSystemContext _context;

        public RepoRootUsers(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddAppUserAsync(RootUser rootUser)
        {
            await _context.RootUsers.AddAsync(rootUser);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAppUserAsync(RootUser rootUser)
        {
            _context.RootUsers.Remove(rootUser);
            return _context.SaveChangesAsync();
        }

        public Task EditAppUserAsync(RootUser rootUser)
        {
            _context.RootUsers.Update(rootUser);
            return _context.SaveChangesAsync();
        }

        public async Task<RootUser> GetAppUserByEmailAsync(string email)
            => await _context.RootUsers.AsNoTracking().FirstOrDefaultAsync(p
                => p.Email == email);

        public async Task<RootUser> GetAppUserByIdAsync(int id)
            => await _context.RootUsers.AsNoTracking().FirstOrDefaultAsync(p
                => p.Id == id);

        public async Task<IEnumerable<RootUser>> ToListAsync()
            => await _context.RootUsers.AsNoTracking().ToListAsync();
    }
}
