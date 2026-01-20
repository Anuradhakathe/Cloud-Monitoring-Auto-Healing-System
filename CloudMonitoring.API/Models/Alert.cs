namespace CloudMonitoring.API.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string Message { get; set; }
        public string AlertType { get; set; }   // Email / SMS
        public DateTime CreatedAt { get; set; }
    }
}
