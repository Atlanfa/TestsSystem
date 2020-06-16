namespace TestsSystem.Core.Models.DbData
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string CorrectAnswer { get; set; }
        public string AnswerVariantA { get; set; }
        public string AnswerVAriantB { get; set; }
        public string AnswerVariantC { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}
