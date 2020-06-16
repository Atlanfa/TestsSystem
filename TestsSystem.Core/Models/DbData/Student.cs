using System.Collections.Generic;

namespace TestsSystem.Core.Models.DbData
{
    public class Student : AppUser
    {
        public string GroupName { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
