using System.Threading.Tasks;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Services.Business
{
    public class ServPrepods : IServPrepods
    {
        private readonly IServSession _session;
        private readonly IServHttpApi _context;

        public ServPrepods(
            IServSession session,
            IServHttpApi context)
        {
            _session = session;
            _context = context;
        }

        public async Task<PrepodMainCard> GetPrepodMainCard()
        {
            var answ = await _context.GetSubjectsFromApiAsync(
                _session.User.Email);

            int count = answ.Subjects != null ?
                answ.Subjects.Count : 0;

            return new PrepodMainCard
            {
                Name = _session.User.Name,
                SubjectCount = count
            };
        }

        public Task AddNewSubjectAsync(FormAddSubject formAddSubject)
            => _context.CreateSubjectAsync(formAddSubject);

        public Task AddNewThemeAsync(FormAddTheme formAddTheme)
            => _context.CreateThemeAsync(formAddTheme);

        public Task AddNewQuestionAsync(FormAddQuestion formAddQuestion)
            => _context.CreateQuestionAsync(formAddQuestion);
    }
}
