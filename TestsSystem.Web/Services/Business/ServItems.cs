using AutoMapper;

using System.Collections.Generic;
using System.Threading.Tasks;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.Forms;

namespace TestsSystem.Web.Services.Business
{
    public class ServItems : IServItems
    {
        private readonly IMapper _mapper;
        private readonly IServSession _session;
        private readonly IServHttpApi _context;

        public ServItems(
            IMapper mapper,
            IServSession session,
            IServHttpApi context)
        {
            _mapper = mapper;
            _session = session;
            _context = context;
        }

        public async Task<List<DtoSubject>> GetSubjectsAsync(string prepodMail)
        {
            var answ = await _context.GetSubjectsFromApiAsync(prepodMail);
            return answ.Subjects;
        }

        public async Task<List<DtoTheme>> GetThemesAsync(int subjectId)
        {
            var answ = await _context.GetThemesFromApiAsync(subjectId);
            return answ.Themes;
        }

        public async Task<List<DtoQuestion>> GetQuestionsAsync(int themeId)
        {
            var answ = await _context.GetQuestionsFromApiAsync(themeId);
            return answ.Questions;
        }

        public async Task<DtoQuestion> GetQuestionAsync(int questionId)
        {
            var answ = await _context.GetQuestionFromApiAsync(questionId);
            return answ.Question;
        }

        public Task BindQuestionsToStudent(List<FormBindedData> questions)
            => _context.BindQuestionsAsync(_mapper.Map<List<FormBindQuestion>>(questions));
    }
}
