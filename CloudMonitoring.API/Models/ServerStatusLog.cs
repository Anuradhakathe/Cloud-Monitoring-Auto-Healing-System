namespace CloudMonitoring.API.Models
{
    public class ServerStatusLog
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public int CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public string Status { get; set; }
        public DateTime CheckedAt { get; set; }
    }
}
