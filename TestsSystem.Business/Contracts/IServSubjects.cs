using System.Threading.Tasks;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Business.Contracts
{
    public interface IServSubjects
    {
        Task<AnswerBase> CreateSubjectAsync(DtoCreateSubject dto);
        Task<AnswerBase> GetSubjectsAsync(string prepodEmail);
    }
}
