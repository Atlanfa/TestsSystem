using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.SqlData.Repositories
{
    public class RepoStudents : IRepoStudents
    {
        private readonly TestsSystemContext _context;

        public RepoStudents(TestsSystemContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public Task DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            return _context.SaveChangesAsync();
        }

        public Task EditStudentAsync(Student student)
        {
            _context.Students.Update(student);
            return _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
            => await _context.Students.AsNoTracking().Include(s
                => s.Answers).FirstOrDefaultAsync(p => p.Email == email);

        public async Task<Student> GetStudentByIdAsync(int id)
            => await _context.Students.AsNoTracking().Include(s
                => s.Answers).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Student>> ToListAsync()
            => await _context.Students.AsNoTracking().Include(s
                => s.Answers).ToListAsync();
    }
}
