using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.DbData;
using TestsSystem.Core.Models.Server.Answers;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.Business.Services
{
    public class ServQuestions : IServQuestions
    {
        private readonly IMapper _mapper;
        private readonly IRepoQuestions _repoQuestions;

        public ServQuestions(
            IMapper mapper,
            IRepoQuestions repoQuestions)
        {
            _mapper = mapper;
            _repoQuestions = repoQuestions;
        }

        public async Task<AnswerBase> CreateQuestionAsync(DtoCreateQuestion dto)
        {
            await _repoQuestions.AddQuestionAsync(_mapper.Map<Question>(dto));
            return new AnswerSuccess { };
        }

        public async Task<AnswerBase> GetQuestionAsync(int questionId)
        {
            var question = await _repoQuestions.GetQuestionByIdAsync(questionId);
            return new AnswerQuestion
            {
                Question = _mapper.Map<DtoQuestion>(question)
            };
        }

        public async Task<AnswerBase> GetQuestionsAsync(int themeId)
        {
            var questions = (await _repoQuestions.ToListAsync())
                .Where(q => q.ThemeId == themeId);
            return new AnswerQuestions
            {
                Questions = _mapper.Map<List<DtoQuestion>>(questions)
            };
        }
    }
}
