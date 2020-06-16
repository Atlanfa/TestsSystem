using Microsoft.AspNetCore.Http;

using TestsSystem.Web.Contracts;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models;
using TestsSystem.Web.Models.VO;

using static TestsSystem.Web.Helper.StringConstant;

namespace TestsSystem.Web.Services.Business
{
    public class ServSession : SessionBase, IServSession
    {
        public ServSession(IHttpContextAccessor accessor)
            : base(accessor) { }

        public bool HasExpired
            => User.ToBoolenExpire();

        public SessionUser User
            => Session.GetObj<SessionUser>(SESSION_USER);

        public void RemoveUserSession()
            => Session.Remove(SESSION_USER);

        public void UpdateUserSession(SessionUser user)
        {
            Session.Remove(SESSION_USER);
            Session.SetObj(SESSION_USER, user);
        }
    }
}
