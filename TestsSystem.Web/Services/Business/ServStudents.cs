using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.Interlayers;
using TestsSystem.Web.Models.UI;

using static TestsSystem.Web.Helper.StringConstant;

namespace TestsSystem.Web.Services.Business
{
    public class ServStudents : IServStudents
    {
        private readonly IServItems _servItems;
        private readonly IServSession _session;
        private readonly IServHttpApi _context;

        public ServStudents(
            IServItems servItems,
            IServSession session,
            IServHttpApi context)
        {
            _servItems = servItems;
            _session = session;
            _context = context;
        }

        public async Task<InterlayerCallback> CalculateAnswerAsync(FormGiveAnswer form)
        {
            var question = await _servItems.GetQuestionAsync(form.QuestionId);
            bool isSuccessful = question.CorrectAnswer.Contains(form.ChekedAnswer);

            await _context.UpdateAnswerAsync(new DtoAnswer
            {
                Id = form.AnswerId,
                QuestionId = form.QuestionId,
                TryCount = form.CurrentTryCount,
                IsSuccessful = isSuccessful,
                State = form.CurrentTryCount == 0 || isSuccessful ? CLOSED : ISSUED
            });

            return new InterlayerCallback
            {
                IsSuccess = isSuccessful,
                Reason = isSuccessful ? "Гарна спроба, ви впоралися з питанням"
                    : $"Невдача. У вас залишилося спроб: {form.CurrentTryCount}"
            };
        }

        public async Task<StudentMainCard> GetStudentMainCardAsync()
        {
            var answ = await _context.GetAnswersFromApiAsync(_session.User.Email);

            return new StudentMainCard
            {
                Name = _session.User.Name,
                IsSturtedTemplate = true,
                Answers = answ.Answers,
                Notification = null
            };
        }
    }
}
