using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.DbData;
using TestsSystem.Core.Models.Server.Answers;
using TestsSystem.SqlData.Contracts;

namespace TestsSystem.Business.Services
{
    public class ServSubjects : IServSubjects
    {
        private readonly IMapper _mapper;
        private readonly IRepoPrepods _prepods;
        private readonly IRepoSubjects _repoSubjects;

        public ServSubjects(
            IMapper mapper,
            IRepoPrepods prepods,
            IRepoSubjects repoSubjects)
        {
            _mapper = mapper;
            _prepods = prepods;
            _repoSubjects = repoSubjects;
        }

        public async Task<AnswerBase> CreateSubjectAsync(DtoCreateSubject dto)
        {
            var prepod = await _prepods.GetPrepodByEmailAsync(dto.PrepodMail);
            await _repoSubjects.AddSubjectnAsync(new Subject
            {
                PrepodId = prepod.Id,
                Name = dto.SubjectName
            });
            return new AnswerSuccess { };
        }

        public async Task<AnswerBase> GetSubjectsAsync(string prepodEmail)
        {
            var prepod = await _prepods.GetPrepodByEmailAsync(prepodEmail);
            if (prepod != null) return new AnswerSubjects
            {
                Subjects = _mapper.Map<List<DtoSubject>>(prepod.Subjects)
            };
            else return new AnswerFail
            {
                Reason = "No this prepod in DB"
            };
        }
    }
}
