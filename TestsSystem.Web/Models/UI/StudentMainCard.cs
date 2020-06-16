using System.Collections.Generic;

using TestsSystem.Core.DTO;

namespace TestsSystem.Web.Models.UI
{
    public class StudentMainCard
    {
        public string Name { get; set; }
        public bool IsSturtedTemplate { get; set; }
        public PartialNotification Notification { get; set; }
        public List<DtoAnswer> Answers { get; set; }
    }
}
