using Moq;

using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

using Xunit;

namespace TestsSystem.Tests
{
    public class ServSubjectsTests
    {
        [Fact]
        public void GetSubjectsTests()
        {
            // Arrange
            var mock = new Mock<IRepoPrepods>();
            mock.Setup(repo => repo.GetPrepodByEmailAsync("email")).Returns(Prepod);

            // Act
            var result = mock.Object.GetPrepodByEmailAsync("email");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<Prepod>>(result);
        }

        private Task<Prepod> Prepod
            => Task.Run(() => new Prepod
            {
                Id = 2,
                Email = "mail2@mail.ru",
                Name = "Andrey2",
                SecondName = "Vesnin2",
                Password = "789"
            });
    }
}
