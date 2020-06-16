using Moq;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestsSystem.Core.Models.DbData;
using TestsSystem.SqlData.Contracts;

using Xunit;

namespace TestsSystem.Tests
{
    public class ServQuestionsTests
    {
        [Fact]
        public void GetQuestionsTests()
        {
            // Arrange
            var mock = new Mock<IRepoQuestions>();
            mock.Setup(repo => repo.ToListAsync()).Returns(Questions);

            // Act
            var result = mock.Object.ToListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<IEnumerable<Question>>>(result);
        }

        [Fact]
        public void GetQuestionTests()
        {
            // Arrange
            var mock = new Mock<IRepoQuestions>();
            mock.Setup(repo => repo.GetQuestionByIdAsync(1)).Returns(Question);

            // Act
            var result = mock.Object.GetQuestionByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Task<Question>>(result);
        }

        private Task<IEnumerable<Question>> Questions
            => Task.Run(() => new List<Question>
            {
                new Question
                {
                    Id = 1,
                    AnswerVariantA = "varA-1",
                    AnswerVAriantB = "varB-1",
                    AnswerVariantC = "varC-1",
                    CorrectAnswer = "correct-1"
                },
                new Question
                {
                    Id = 2,
                    AnswerVariantA = "varA-2",
                    AnswerVAriantB = "varB-2",
                    AnswerVariantC = "varC-2",
                    CorrectAnswer = "correct-21"
                }
            }.AsEnumerable());

        private Task<Question> Question
            => Task.Run(() => new Question
            {
                Id = 3,
                AnswerVariantA = "varA-3",
                AnswerVAriantB = "varB-3",
                AnswerVariantC = "varC-3",
                CorrectAnswer = "correct-3"
            });
    }
}
