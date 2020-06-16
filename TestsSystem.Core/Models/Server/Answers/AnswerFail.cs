namespace TestsSystem.Core.Models.Server.Answers
{
    public class AnswerFail : AnswerBase
    {
        public override bool IsSuccess => false;
        public string Reason { get; set; }
    }
}
