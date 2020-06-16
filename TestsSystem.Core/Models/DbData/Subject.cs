using System.Collections.Generic;

namespace TestsSystem.Core.Models.DbData
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PrepodId { get; set; }
        public Prepod Prepod { get; set; }

        public List<Theme> Themes { get; set; }
    }
}
