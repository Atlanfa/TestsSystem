using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

using Xunit;

namespace TestsSystem.Tests
{
    public class ServAnswersTests
    {
        [Fact]
        public void GetAnswersTests()
        {
            // Arrange
            var mock = new Mock<IRepoAnswers>();
            mock.Setup(repo => repo.ToListAsync()).Returns(Answers);

            // Act
            var result = mock.Object.ToListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<IEnumerable<Answer>>>(result);
        }

        [Fact]
        public void GetAnswerTests()
        {
            // Arrange
            var mock = new Mock<IRepoAnswers>();
            mock.Setup(repo => repo.GetAnswerByIdAsync(1)).Returns(Answer);

            // Act
            var result = mock.Object.GetAnswerByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<Answer>>(result);
        }

        private Task<IEnumerable<Answer>> Answers
            => Task.Run(() => new List<Answer>
            {
                new Answer
                {
                    Id = 1,
                    IsSuccessful = true,
                    QuestionId = 2,
                    State = "issued",
                    StudentId = 2,
                    TryCount = 2
                },
                new Answer
                {
                    Id = 2,
                    IsSuccessful = true,
                    QuestionId = 3,
                    State = "issued",
                    StudentId = 3,
                    TryCount = 3
                }
            }.AsEnumerable());

        private Task<Answer> Answer
            => Task.Run(() => new Answer
            {
                Id = 1,
                IsSuccessful = true,
                QuestionId = 2,
                State = "issued",
                StudentId = 2,
                TryCount = 2
            });
    }
}
