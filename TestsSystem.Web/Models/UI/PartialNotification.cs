namespace TestsSystem.Web.Models.UI
{
    public class PartialNotification
    {
        public bool IsSuccess { private get; set; }
        public string SessionUserName { get; set; }
        public string NotifyMessage { get; set; }
        public string AlertType => IsSuccess ? 
            "alert-success" : "alert-warning";
    }
}
