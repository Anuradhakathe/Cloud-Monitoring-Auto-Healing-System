namespace CloudMonitoring.API.Models
{
    public class ServerStatus
    {
        public string ServerName { get; set; }
        public int CpuUsage { get; set; }        // percentage
        public int MemoryUsage { get; set; }     // percentage
        public string Status { get; set; }
        public DateTime CheckedAt { get; set; }
    }
}
