using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IEmailSender
    {
        public Task SendMail(string mail, string senderName, string subject, string message);
        public Task SendMailToClient(string toMail, string toName, string subject, string message);
    }
}
