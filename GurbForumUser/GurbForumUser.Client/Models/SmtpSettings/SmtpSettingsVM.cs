namespace GurbForumUser.Client.Models.SmtpSettings
{
    public class SmtpSettingsVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Timeout { get; set; }
    }
}
