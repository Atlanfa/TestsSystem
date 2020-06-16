using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData.Contracts
{
    public interface IRepoStudents
    {
        Task<IEnumerable<Student>> ToListAsync();
        Task<Student> GetStudentByEmailAsync(string email);
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task EditStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
