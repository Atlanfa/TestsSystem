using System.Threading.Tasks;

using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.Interlayers;
using TestsSystem.Web.Models.UI;

namespace TestsSystem.Web.Contracts
{
    public interface IServStudents
    {
        public Task<StudentMainCard> GetStudentMainCardAsync();
        public Task<InterlayerCallback> CalculateAnswerAsync(FormGiveAnswer form);
    }
}
