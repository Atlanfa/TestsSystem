namespace TestsSystem.Web.Models.UI
{
    public class ViewSubject
    {
        public int SubjectId { get; set; }
        public bool Expanded { get; set; }
        public string SubjectName { get; set; }

        public string CollapseId
            => string.Format($"_collapse_{SubjectId}");
        public string CollapseHref
            => string.Format($"#{CollapseId}");
        public string LabeledBy
            => string.Format($"_heading_{SubjectId}");
        public string Show => Expanded ? "show" : null;
    }
}
