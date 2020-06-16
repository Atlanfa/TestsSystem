using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

using Xunit;

namespace TestsSystem.Tests
{
    public class ServAppUsersTests
    {
        [Fact]
        public void GetAppUsersTests()
        {
            // Arrange
            var mock = new Mock<IRepoStudents>();
            mock.Setup(repo => repo.ToListAsync()).Returns(Students);

            // Act
            var result = mock.Object.ToListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<IEnumerable<Student>>>(result);
        }

        [Fact]
        public void GetAppUserTests()
        {
            // Arrange
            var mock = new Mock<IRepoStudents>();
            mock.Setup(repo => repo.GetStudentByIdAsync(1)).Returns(Student);

            // Act
            var result = mock.Object.GetStudentByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<Student>>(result);
        }

        private Task<IEnumerable<Student>> Students
            => Task.Run(() => new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Email="mail1@mail.ru",
                    GroupName = "grioup-1",
                    Name = "Andrey",
                    SecondName = "Vesnin",
                    Password = "789"
                },
                new Student
                {
                    Id = 2,
                    Email="mail2@mail.ru",
                    GroupName = "grioup-2",
                    Name = "Andrey2",
                    SecondName = "Vesnin2",
                    Password = "789"
                }
            }.AsEnumerable());

        private Task<Student> Student
            => Task.Run(() => new Student
            {
                Id = 2,
                Email = "mail2@mail.ru",
                GroupName = "grioup-2",
                Name = "Andrey2",
                SecondName = "Vesnin2",
                Password = "789"
            });
    }
}
