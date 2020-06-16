using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Business.Contracts
{
    public interface IServThemes
    {
        Task<AnswerBase> CreateThemeAsync(DtoCreateTheme dto);
        Task<AnswerBase> GetThemesAsync(int subjectId);
    }
}
