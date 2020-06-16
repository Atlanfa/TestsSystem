using AutoMapper;

using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.DbData;

namespace TestsSystem.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DtoAppUser, Student>().ReverseMap();
            CreateMap<DtoAppUser, Prepod>().ReverseMap();
            CreateMap<DtoAppUser, RootUser>().ReverseMap();

            CreateMap<Subject, DtoSubject>();
            CreateMap<Theme, DtoTheme>();
            CreateMap<Question, DtoQuestion>();
            CreateMap<Answer, DtoAnswer>().ReverseMap();

            CreateMap<DtoCreateTheme, Theme>();
            CreateMap<DtoCreateQuestion, Question>();
        }
    }
}
