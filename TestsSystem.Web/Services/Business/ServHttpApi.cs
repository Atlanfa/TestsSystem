using AutoMapper;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.REST;
using TestsSystem.Web.Models.VO;

namespace TestsSystem.Web.Services.Business
{
    public class ServHttpApi : IServHttpApi
    {
        private readonly IMapper _mapper;
        private readonly HttpContext _context;

        public ServHttpApi(
            IMapper mapper,
            HttpContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseBase> CreateAppUserAsync(FormRegisterUser registerUser)
            => await _context.HttpPostAsync<ResponseBase>(new RequestCreateAppUser(registerUser));

        public async Task CreateSubjectAsync(FormAddSubject formAddSubject)
            => await _context.HttpPostAsync<ResponseBase>(new RequestCreateSubject(
                _mapper.Map<DtoCreateSubject>(formAddSubject)));

        public async Task CreateThemeAsync(FormAddTheme formAddTheme)
            => await _context.HttpPostAsync<ResponseBase>(new RequesCreateTheme(formAddTheme));

        public async Task CreateQuestionAsync(FormAddQuestion formAddQuestion)
            => await _context.HttpPostAsync<ResponseBase>(new RequestAddQuestion(formAddQuestion));

        public async Task<ResponseAppUser> GetAppUserFromApiAsync(FormLoginUser loginUser)
            => await _context.HttpGetAsync<ResponseAppUser>(new RequestGetAppUser(loginUser));

        public async Task<ResponseAppUsers> GetAppUsersFromApiAsync(string role)
            => await _context.HttpGetAsync<ResponseAppUsers>(new RequestGetAppUsers(role));

        public async Task<ResponseSubjects> GetSubjectsFromApiAsync(string prepodMail)
            => await _context.HttpGetAsync<ResponseSubjects>(new RequestGetSubjects(prepodMail));

        public async Task<ResponseThemes> GetThemesFromApiAsync(int subjectId)
            => await _context.HttpGetAsync<ResponseThemes>(new RequestGetThemes(subjectId));

        public async Task<ResponseQuestions> GetQuestionsFromApiAsync(int themeId)
            => await _context.HttpGetAsync<ResponseQuestions>(new RequestGetQuestions(themeId));

        public async Task<ResponseAnswers> GetAnswersFromApiAsync(string studMail)
            => await _context.HttpGetAsync<ResponseAnswers>(new RequestGetAnswers(studMail));

        public async Task BindQuestionsAsync(List<FormBindQuestion> questions)
            => await _context.HttpPostAsync<ResponseBase>(new RequestBindQuestions(questions));

        public async Task<ResponseQuestion> GetQuestionFromApiAsync(int questionId)
            => await _context.HttpGetAsync<ResponseQuestion>(new RequestGetQuestion(questionId));

        public async Task UpdateAnswerAsync(DtoAnswer answer)
            => await _context.HttpPutAsync<ResponseBase>(new RequestUpdateAnswer(answer));
    }
}
