using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoPrepods : IRepoPrepods
    {
        private readonly TestsSystemContext _context;

        public RepoPrepods(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddPrepodAsync(Prepod prepod)
        {
            await _context.Prepods.AddAsync(prepod);
            await _context.SaveChangesAsync();
        }

        public Task DeletePrepodAsync(Prepod prepod)
        {
            _context.Prepods.Remove(prepod);
            return _context.SaveChangesAsync();
        }

        public Task EditPrepodAsync(Prepod prepod)
        {
            _context.Prepods.Update(prepod);
            return _context.SaveChangesAsync();
        }

        public async Task<Prepod> GetPrepodByEmailAsync(string email)
            => await _context.Prepods.AsNoTracking().Include(p
                => p.Subjects).FirstOrDefaultAsync(p => p.Email == email);

        public async Task<Prepod> GetPrepodByIdAsync(int id)
            => await _context.Prepods.AsNoTracking().Include(p
                => p.Subjects).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Prepod>> ToListAsync()
            => await _context.Prepods.AsNoTracking().Include(p
                => p.Subjects).ToListAsync();
    }
}
