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
    public class ServThemes : IServThemes
    {
        private readonly IMapper _mapper;
        private readonly IRepoThemes _repoThemes;

        public ServThemes(
            IMapper mapper,
            IRepoThemes repoThemes)
        {
            _mapper = mapper;
            _repoThemes = repoThemes;
        }

        public async Task<AnswerBase> CreateThemeAsync(DtoCreateTheme dto)
        {
            await _repoThemes.AddThemesnAsync(_mapper.Map<Theme>(dto));
            return new AnswerSuccess { };
        }

        public async Task<AnswerBase> GetThemesAsync(int subjectId)
        {
            var themes = (await _repoThemes.ToListAsync())
                .Where(t => t.SubjectId == subjectId);
            return new AnswerThemes
            {
                Themes = _mapper.Map<List<DtoTheme>>(themes)
            };
        }
    }
}
