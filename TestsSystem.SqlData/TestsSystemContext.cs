using Microsoft.EntityFrameworkCore;

using TestsSystem.Core.Models.DbData;

namespace TestsSystem.SqlData
{
    public class TestsSystemContext : DbContext
    {
        public DbSet<RootUser> RootUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Prepod> Prepods { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public TestsSystemContext(DbContextOptions<TestsSystemContext> options)
            : base(options) { }
    }
}
