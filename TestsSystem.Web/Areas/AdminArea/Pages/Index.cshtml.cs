using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Areas.AdminArea.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServSession _session;
        private readonly IServHttpApi _httpApi;

        private bool SessionHasExpired
            => _session.User.HasExpired();

        public PartialNotification Notification { get; private set; }

        public IndexModel(
            IServSession session,
            IServHttpApi httpApi)
        {
            _session = session;
            _httpApi = httpApi;
        }

        public IActionResult OnGet()
        {
            if (SessionHasExpired) return Redirect("/");
            else return Page();
        }

        public async Task<IActionResult> OnPostCreateUserAsync(FormRegisterUser registerUser)
        {
            if (SessionHasExpired) return Redirect("/");

            var answ = await _httpApi.CreateAppUserAsync(registerUser);

            Notification = new PartialNotification
            {
                IsSuccess = answ.IsSuccess,
                NotifyMessage = answ.Reason,
                SessionUserName = _session.User.Name
            };

            if (!answ.IsSuccess) Notification.NotifyMessage = "Something went wrong, try again";
            else Notification.NotifyMessage = string
                    .Format($"Користувача {registerUser.Name} {registerUser.SecondName} успішно створено");
            return Page();
        }

        public async Task<PartialViewResult> OnPostAppUsersAsync(string role)
        {
            var answ = await _httpApi.GetAppUsersFromApiAsync(role);

            if (!answ.IsSuccess) return Partial("_Partial_Notification", new PartialNotification
            {
                IsSuccess = answ.IsSuccess,
                SessionUserName = _session.User.Name,
                NotifyMessage = answ.Reason
            });

            return Partial("_Partial_Admin_AppUsersTable", answ.AppUsers);
        }

        public IActionResult OnPostLogout()
        {
            _session.RemoveUserSession(); ;
            return Redirect("/");
        }
    }
}
