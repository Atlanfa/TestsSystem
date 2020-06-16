using TestsSystem.Core.Enums;

namespace TestsSystem.Web.Models.Forms
{
    public class FormEditUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; }
    }
}
