namespace Orb.Data.Models.Session
{
    public class Status
    {
        public string code { get; set; }
        public string orbSessionId { get; set; }
        public string deviceIpAddress { get; set; }
        public string maxInactiveInterval { get; set; }
        public string orbVersion { get; set; }

    }
}
