using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

using Xunit;

namespace TestsSystem.Tests
{
    public class ServThemesTests
    {
        [Fact]
        public void GetSubjectsTests()
        {
            // Arrange
            var mock = new Mock<IRepoThemes>();
            mock.Setup(repo => repo.ToListAsync()).Returns(Themes);

            // Act
            var result = mock.Object.ToListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<IEnumerable<Theme>>>(result);
        }

        private Task<IEnumerable<Theme>> Themes
            => Task.Run(() => new List<Theme>
            {
                new Theme
                {
                    Id = 1,
                    Name = "Ruslan-1",
                    SubjectId = 1
                },
                new Theme
                {
                    Id = 2,
                    Name = "Ruslan-2",
                    SubjectId = 2
                }
            }.AsEnumerable());
    }
}
