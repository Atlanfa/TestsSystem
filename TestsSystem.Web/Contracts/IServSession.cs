using TestsSystem.Web.Models;

namespace TestsSystem.Web.Contracts
{
    public interface IServSession
    {
        bool HasExpired { get; }
        SessionUser User { get; }

        void RemoveUserSession();
        void UpdateUserSession(SessionUser user);
    }
}
