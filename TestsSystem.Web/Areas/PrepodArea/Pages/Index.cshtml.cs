using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

using static TestsSystem.Web.Helper.StringConstant;

namespace TestsSystem.Web.Areas.PrepodArea.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServSession _session;
        private readonly IServPrepods _servPrepods;
        private readonly IServItems _servItems;

        private bool SessionHasExpired
            => _session.User.HasExpired();

        public PrepodMainCard PrepodMainCard { get; set; }

        public IndexModel(
            IServSession session,
            IServPrepods servPrepods,
            IServItems servItems)
        {
            _session = session;
            _servPrepods = servPrepods;
            _servItems = servItems;
        }

        public async Task<IActionResult> OnGet()
        {
            if (SessionHasExpired) return Redirect("/");

            await GetPrepodMainCardView(true);
            return Page();
        }

        public async Task<PartialViewResult> OnPostItemsAsync(string item)
        {
            await GetPrepodMainCardView(true);

            return (item) switch
            {
                SUBJECTS => Partial("_Prepod_MainCard", PrepodMainCard),
                STUDENT => Partial("_Partial_Questions_Card", new ConnectQuestionCard
                {
                    Notification = null
                }),
                _ => null
            };
        }

        public async Task<IActionResult> OnPostAddSabjectAsync(FormAddSubject form)
        {
            if (SessionHasExpired) return Redirect("/");

            await _servPrepods.AddNewSubjectAsync(form);

            await GetPrepodMainCardView(true, new PartialNotification
            {
                IsSuccess = true,
                SessionUserName = _session.User.Name,
                NotifyMessage = $"Предмет \"{form.Name}\" успішно створено"
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAddThemeAsync(FormAddTheme form)
        {
            if (SessionHasExpired) return Redirect("/");

            await _servPrepods.AddNewThemeAsync(form);

            await GetPrepodMainCardView(true, new PartialNotification
            {
                IsSuccess = true,
                SessionUserName = _session.User.Name,
                NotifyMessage = $"Тему \"{form.Name}\" успішно створено"
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAddQuestionAsync(FormAddQuestion formAddQuestion)
        {
            if (SessionHasExpired) return Redirect("/");

            await _servPrepods.AddNewQuestionAsync(formAddQuestion);

            await GetPrepodMainCardView(true, new PartialNotification
            {
                IsSuccess = true,
                SessionUserName = _session.User.Name,
                NotifyMessage = $"Ваше питання успішно створено"
            });

            return Page();
        }

        public async Task<PartialViewResult> OnPostChangeSubjectSelectAsync(int subjId)
            => Partial("_Select_Themes", await _servItems.GetThemesAsync(subjId));

        public async Task<PartialViewResult> OnPostChangeThemesSelectAsync(int themeId)
            => Partial("_Partial_SelectedQuestionsTable", await _servItems.GetQuestionsAsync(themeId));

        public Task OnPostBindQuestionsAsync(List<FormBindedData> questions)
            => _servItems.BindQuestionsToStudent(questions);

        public IActionResult OnPostLogout()
        {
            _session.RemoveUserSession(); ;
            return Redirect("/");
        }

        private async Task GetPrepodMainCardView(bool isSturted, PartialNotification notification = null)
        {
            PrepodMainCard = await _servPrepods.GetPrepodMainCard();
            PrepodMainCard.IsSturtedTemplate = isSturted;
            PrepodMainCard.Notification = notification;
        }
    }
}
