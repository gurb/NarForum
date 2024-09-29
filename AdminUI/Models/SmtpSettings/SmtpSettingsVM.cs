namespace AdminUI.Models.SmtpSettings
{
    public class SmtpSettingsVM
    {
        public Guid? Id { get; set; }
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Timeout { get; set; }
    }
}
