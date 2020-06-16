using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoSubjects : IRepoSubjects
    {
        private readonly TestsSystemContext _context;

        public RepoSubjects(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddSubjectnAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public Task DeleteSubjectAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
            return _context.SaveChangesAsync();
        }

        public Task EditSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            return _context.SaveChangesAsync();
        }

        public async Task<Subject> GetSubjectsByIdAsync(int id)
            => await _context.Subjects.AsNoTracking().Include(s
                => s.Themes).FirstOrDefaultAsync(s
                    => s.Id == id);

        public async Task<IEnumerable<Subject>> ToListAsync()
            => await _context.Subjects.AsNoTracking()
                .Include(s => s.Themes).ToListAsync();
    }
}
