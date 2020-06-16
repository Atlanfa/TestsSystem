using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestsSystem.Core.Models.DbData
{
    public class Prepod : AppUser
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public List<Subject> Subjects { get; set; }
    }
}
