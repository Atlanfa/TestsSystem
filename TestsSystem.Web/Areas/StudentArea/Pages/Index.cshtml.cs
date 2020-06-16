using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Areas.StudentArea.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServSession _session;
        private readonly IServStudents _servStudents;
        private readonly IServItems _servItems;

        private bool SessionHasExpired
            => _session.User.HasExpired();

        public StudentMainCard StudentMainCard { get; set; }

        public IndexModel(
            IServSession session,
            IServStudents servStudents,
            IServItems servItems)
        {
            _session = session;
            _servStudents = servStudents;
            _servItems = servItems;
        }

        public async Task<IActionResult> OnGet()
        {
            if (SessionHasExpired) return Redirect("/");

            await GetStudentMainCardView(true);
            return Page();
        }

        public async Task<IActionResult> OnPostGiveAnswerAsync(FormGiveAnswer form)
        {
            if (SessionHasExpired) return Redirect("/");

            var callback = await _servStudents.CalculateAnswerAsync(form);
            await GetStudentMainCardView(true, new PartialNotification
            {
                IsSuccess = callback.IsSuccess,
                SessionUserName = _session.User.Name,
                NotifyMessage = callback.Reason
            });
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            _session.RemoveUserSession(); ;
            return Redirect("/");
        }

        private async Task GetStudentMainCardView(bool isSturted, PartialNotification notification = null)
        {
            StudentMainCard = await _servStudents.GetStudentMainCardAsync();
            StudentMainCard.IsSturtedTemplate = isSturted;
            StudentMainCard.Notification = notification;
        }
    }
}
