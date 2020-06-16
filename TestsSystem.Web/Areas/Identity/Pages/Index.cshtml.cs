using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.Forms;

using static TestsSystem.Web.Helper.StringConstant;

namespace TestsSystem.Web.Areas.Identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAuthManager _authManager;

        [BindProperty(SupportsGet = true)]
        public string IdentityState { get; set; }

        public IndexModel(
            IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public IActionResult OnGet()
            => Redirect("/");

        public IActionResult OnGetLogin()
        {
            IdentityState = LOGIN;
            return Page();
        }

        public async Task<IActionResult> OnPostLogin(FormLoginUser loginUser)
        {
            var answ = await _authManager.LoginAsync(loginUser);

            if (!answ.IsSuccess)
            {
                TempData["LoginNotification"] = answ.Reason;
                IdentityState = LOGIN;
                return Page();
            }

            return (loginUser.Role) switch
            {
                "Admin" => RedirectToPage("/Index", new { area = "AdminArea" }),
                "Prepod" => RedirectToPage("/Index", new { area = "PrepodArea" }),
                "Student" => RedirectToPage("/Index", new { area = "StudentArea" }),
                _ => Redirect("/")
            };
        }
    }
}
