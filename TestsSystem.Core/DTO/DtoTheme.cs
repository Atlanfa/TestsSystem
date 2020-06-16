using System.Collections.Generic;

namespace TestsSystem.Core.DTO
{
    public class DtoTheme
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DtoQuestion> Questions { get; set; }
    }
}
