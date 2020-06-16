using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoAnswers : IRepoAnswers
    {
        private readonly TestsSystemContext _context;

        public RepoAnswers(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAnswerAsync(Answer answer)
        {
            _context.Answers.Remove(answer);
            return _context.SaveChangesAsync();
        }

        public Task EditAnswerAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            return _context.SaveChangesAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
            => await _context.Answers.AsNoTracking().Include(a
                => a.Student).Include(a => a.Question)
                    .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Answer>> ToListAsync()
            => await _context.Answers.AsNoTracking().Include(a
                => a.Student).Include(a => a.Question).ToListAsync();
    }
}
