using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Enums;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Business.Contracts
{
    public interface IServAppUsers
    {
        Task<AnswerBase> GetAppUserAsync(EUserRole role, int id = 0, string email = null);
        Task<AnswerBase> GetAppUsersAsync(EUserRole role);
        Task DeleteAppUserAsync(int id, EUserRole role);
        Task UpdateAppUserAsync(DtoAppUser appUser);
        Task CreateAppUserAsync(DtoAppUser appUser);
    }
}
