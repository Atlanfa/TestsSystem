using System.Threading.Tasks;

using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Contracts
{
    public interface IServPrepods
    {
        public Task<PrepodMainCard> GetPrepodMainCard();

        public Task AddNewSubjectAsync(FormAddSubject formAddSubject);
        public Task AddNewThemeAsync(FormAddTheme formAddTheme);
        public Task AddNewQuestionAsync(FormAddQuestion formAddQuestion);
    }
}
