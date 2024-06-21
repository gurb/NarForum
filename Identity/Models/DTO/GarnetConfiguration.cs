namespace Identity.Models.DTO
{
    public class GarnetConfiguration
    {
        public int Port { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool UseTLS { get; set; }
    }
}
