namespace TestsSystem.Core.DTO
{
    public class DtoCreateQuestion
    {
        public int ThemeId { get; set; }
        public string QuestionName { get; set; }
        public string CorrectAnswer { get; set; }
        public string AnswerVariantA { get; set; }
        public string AnswerVAriantB { get; set; }
        public string AnswerVariantC { get; set; }
    }
}
