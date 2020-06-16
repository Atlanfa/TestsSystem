using System.Collections.Generic;

namespace TestsSystem.Core.DTO
{
    public class DtoSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DtoAppUser Prepod { get; set; }

        public List<DtoTheme> Themes { get; set; }
    }
}
