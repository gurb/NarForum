using Application.Contracts.Persistence;
using Domain;
using System.Net;
using System.Net.Mail;

namespace Persistence.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISmtpSettingsService _settingsService;

        SmtpSettings? settings;

        SmtpClient? _client;

        public EmailSender(ISmtpSettingsService settingsService)
        {

            _settingsService = settingsService;
        }

        public async Task SendMail(string senderMail, string senderName, string subject, string message)
        {
            try
            {
                if (settings == null)
                {
                    settings = await _settingsService.GetAsync();

                    if (settings != null)
                    {
                        _client = new SmtpClient(settings.Server, settings.Port)
                        {
                            Credentials = new NetworkCredential(settings.Username, settings.Password),
                            EnableSsl = true
                        };
                    }
                }

                if (_client != null && settings != null)
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(senderMail, senderName),
                        Subject = subject,
                        Body = message,
                        IsBodyHtml = false,
                    };

                    mailMessage.To.Add(settings.Username);

                    await _client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex) 
            {
               
            }
            
        }

        public async Task SendMailToClient(string toMail, string toName, string subject, string message)
        {
            try
            {
                if (settings == null)
                {
                    settings = await _settingsService.GetAsync();

                    if (settings != null)
                    {
                        _client = new SmtpClient(settings.Server, settings.Port)
                        {
                            Credentials = new NetworkCredential(settings.Username, settings.Password),
                            EnableSsl = true
                        };
                    }
                }

                if (_client != null && settings != null)
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(settings.Username, "NarForum"),
                        Subject = subject,
                        Body = message,
                        IsBodyHtml = false,
                    };

                    mailMessage.To.Add(toMail);

                    await _client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
