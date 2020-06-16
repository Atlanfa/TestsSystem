using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoQuestions : IRepoQuestions
    {
        private readonly TestsSystemContext _context;

        public RepoQuestions(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public Task DeleteQuestionAsync(Question question)
        {
            _context.Questions.Remove(question);
            return _context.SaveChangesAsync();
        }

        public Task EditQuestionAsync(Question question)
        {
            _context.Questions.Update(question);
            return _context.SaveChangesAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
            => await _context.Questions.AsNoTracking().Include(q
                => q.Theme).FirstOrDefaultAsync(q => q.Id == id);

        public async Task<IEnumerable<Question>> ToListAsync()
            => await _context.Questions.AsNoTracking().Include(q
                => q.Theme).ToListAsync();
    }
}
