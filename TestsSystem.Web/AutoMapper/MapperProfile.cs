using AutoMapper;

using TestsSystem.Core.DTO;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models;
using TestsSystem.Web.Models.Forms;
using TestsSystem.Web.Models.Interlayers;
using TestsSystem.Web.Models.REST;

namespace TestsSystem.Web.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ResponseAppUser, InterlayerCallback>();

            CreateMap<DtoAppUser, SessionUser>();

            CreateMap<FormAddSubject, DtoCreateSubject>()
                .ForMember(x => x.PrepodMail, x => x.MapFrom(s => s.Prepod))
                .ForMember(x => x.SubjectName, x => x.MapFrom(s =>s.Name));

            CreateMap<FormBindedData, FormBindQuestion>()
                .ForMember(x => x.QuestionId, x => x.MapFrom(s => s.QuestionData.ToId()))
                .ForMember(x => x.TryCount, x => x.MapFrom(s => s.QuestionData.ToTryCount()));
        }
    }
}
