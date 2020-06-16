using TestsSystem.Core.Enums;

namespace TestsSystem.Core.Models.DbData
{
    public abstract class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; }
    }
}
