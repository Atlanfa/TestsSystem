using AutoMapper;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.Business.Services
{
    public class ServAnswers : IServAnswers
    {
        private readonly IMapper _mapper;
        private readonly IRepoAnswers _repoAnswers;
        private readonly IRepoStudents _repoStudents;

        public ServAnswers(
            IMapper mapper,
            IRepoAnswers repoAnswers,
            IRepoStudents repoStudents)
        {
            _mapper = mapper;
            _repoAnswers = repoAnswers;
            _repoStudents = repoStudents;
        }

        public async Task<AnswerBase> AddIssuedAnswersAsync(List<DtoCreateAnswer> answers)
        {
            foreach (var answ in answers)
            {
                var student = await _repoStudents.GetStudentByEmailAsync(answ.StudentId);
                await _repoAnswers.AddAnswerAsync(new Core.Models.DbData.Answer
                {
                    StudentId = student.Id,
                    QuestionId = answ.QuestionId,
                    TryCount = answ.TryCount,
                    State = answ.State,
                });
            }
            return new AnswerSuccess { };
        }

        public async Task<AnswerBase> GetAnswersAsync(string userMail)
        {
            var student = await _repoStudents.GetStudentByEmailAsync(userMail);
            var answers = await _repoAnswers.ToListAsync();
            return new AnswerAnswers
            {
                Answers = _mapper.Map<List<DtoAnswer>>(answers.Where(a
                => a.StudentId == student.Id))
            };
        }

        public async Task<AnswerBase> UpdateAnswerAsync(int answId, DtoAnswer answer)
        {
            var answ = await _repoAnswers.GetAnswerByIdAsync(answId);

            await _repoAnswers.EditAnswerAsync(_mapper.Map(answer, answ));

            throw new System.NotImplementedException();
        }
    }
}
