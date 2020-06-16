using AutoMapper;

using Microsoft.Extensions.Options;

using System;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Security;
using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.Interlayers;

namespace TestsSystem.Web.Services.Business
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly IServSession _servSession;
        private readonly IServHttpApi _servHttpApi;
        private readonly int _duration;

        public AuthManager(
            IMapper mapper,
            IServSession servSession,
            IServHttpApi servHttpApi,
            IOptions<WebViewSettings> options)
        {
            _mapper = mapper;
            _servSession = servSession;
            _servHttpApi = servHttpApi;
            _duration = options.Value.SessionDuration;
        }

        public Task<InterlayerCallback> RegisterAsync(FormRegisterUser registerUser)
        {
            throw new NotImplementedException();
        }

        public async Task<InterlayerCallback> LoginAsync(FormLoginUser loginUser)
        {
            var answ = await _servHttpApi.GetAppUserFromApiAsync(loginUser);

            if (answ.IsSuccess && answ.AppUser != null) CreateSessionUser(answ.AppUser);

            return _mapper.Map<InterlayerCallback>(answ);
        }

        public Task<InterlayerCallback> EditUserAsync(FormEditUser editUser)
        {
            throw new NotImplementedException();
        }

        private void CreateSessionUser(DtoAppUser dtoAppUser)
        {
            var sessionUser = _mapper.Map<SessionUser>(dtoAppUser);
            sessionUser.Expiration = DateTimeOffset.UtcNow
                .AddMinutes(_duration).ToUnixTimeMilliseconds();

            _servSession.UpdateUserSession(sessionUser);
        }
    }
}
