namespace CloudMonitoring.API.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string Issue { get; set; }
        public string Severity { get; set; }   // Warning / Critical
        public DateTime CreatedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
