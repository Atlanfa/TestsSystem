using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Contracts
{
    public interface IServItems
    {
        Task BindQuestionsToStudent(List<FormBindedData> questions);

        Task<List<DtoSubject>> GetSubjectsAsync(string prepodMail);
        Task<List<DtoTheme>> GetThemesAsync(int subjectId);
        Task<List<DtoQuestion>> GetQuestionsAsync(int themeId);

        Task<DtoQuestion> GetQuestionAsync(int questionId);
    }
}
