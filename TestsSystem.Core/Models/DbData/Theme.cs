using System.Collections.Generic;

namespace TestsSystem.Core.Models.DbData
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public List<Question> Questions { get; set; }
    }
}
