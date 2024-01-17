using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSender;
using MimeKit;

namespace EmailSender
{
    public interface IEmailSender
    {
        MimeMessage CreateEmailMessage(Message message);

        Task SendAsync(List<MimeMessage> mailMessages);
    }
}
