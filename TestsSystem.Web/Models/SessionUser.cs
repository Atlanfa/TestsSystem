using TestsSystem.Core.Enums;

namespace TestsSystem.Web.Models
{
    public class SessionUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; }
        public string GroupName { get; set; }
        public long Expiration { get; set; }
    }
}
