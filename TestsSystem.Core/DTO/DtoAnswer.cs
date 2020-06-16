namespace TestsSystem.Core.DTO
{
    public class DtoAnswer
    {
        public int Id { get; set; }

        public int TryCount { get; set; }
        public string State { get; set; }
        public int AnswerDate { get; set; }
        public bool IsSuccessful { get; set; }

        public int QuestionId { get; set; }
    }
}
