using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSender;
using Services;

namespace Services.Contracts
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
