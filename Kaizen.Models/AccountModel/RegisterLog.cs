namespace Kaizen.Web.Models
{
    public class RegisterLog
    {
        public string UserName { get; set; } = "";
        public DateTime LogDate { get; set; }
        public string Message { get; set; } = "";
        public string Exception { get; set; } = "";
        public string Result { get; set; } = "";
    }
}
