namespace TestsSystem.Web.Models.Forms
{
    public class FormGiveAnswer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string ChekedAnswer { get; set; }
        public int CurrentTryCount { get; set; }
    }
}
