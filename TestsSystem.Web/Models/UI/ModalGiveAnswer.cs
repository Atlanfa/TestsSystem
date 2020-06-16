using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.UI
{
    public class ModalGiveAnswer
    {
        public int AnswerId { get; set; }
        public DtoQuestion Question { get; set; }
    }
}
