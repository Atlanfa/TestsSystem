using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace TestsSystem.Core.Models.DbData
{
    public class Answer
    {
        public int Id { get; set; }

        public int TryCount { get; set; }
        public string State { get; set; }
        public int AnswerDate { get; set; }
        public bool IsSuccessful { get; set; }

        public int StudentId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Student Student { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
