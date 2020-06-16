using System.Threading.Tasks;

using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.Interlayers;

namespace TestsSystem.Web.Contracts
{
    public interface IAuthManager
    {
        Task<InterlayerCallback> LoginAsync(FormLoginUser loginUser);
        Task<InterlayerCallback> RegisterAsync(FormRegisterUser registerUser);
        Task<InterlayerCallback> EditUserAsync(FormEditUser editUser);
    }
}
