using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.REST;

namespace TestsSystem.Web.Contracts
{
    public interface IServHttpApi
    {
        Task<ResponseAppUser> GetAppUserFromApiAsync(FormLoginUser loginUser);
        Task<ResponseAppUsers> GetAppUsersFromApiAsync(string role);
        Task<ResponseBase> CreateAppUserAsync(FormRegisterUser registerUser);

        Task<ResponseSubjects> GetSubjectsFromApiAsync(string prepodMail);
        Task<ResponseThemes> GetThemesFromApiAsync(int subjectId);
        Task<ResponseQuestions> GetQuestionsFromApiAsync(int themeId);
        Task<ResponseQuestion> GetQuestionFromApiAsync(int questionId);
        Task<ResponseAnswers> GetAnswersFromApiAsync(string studMail);

        Task CreateSubjectAsync(FormAddSubject formAddSubject);
        Task CreateThemeAsync(FormAddTheme formAddTheme);
        Task CreateQuestionAsync(FormAddQuestion formAddQuestion);

        Task BindQuestionsAsync(List<FormBindQuestion> questions);
        Task UpdateAnswerAsync(DtoAnswer answer);
    }
}
