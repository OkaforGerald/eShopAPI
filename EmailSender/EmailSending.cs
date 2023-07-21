﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EmailSender;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Services.Contracts;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Services
{
    public class EmailSending : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSending(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            var builder = new BodyBuilder();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.UserName));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            if (message.Product != null)
            {
                using (StreamReader source = System.IO.File.OpenText(Directory.GetCurrentDirectory() + "\\wwwroot\\Templates\\index.html"))
                {
                    builder.HtmlBody = source.ReadToEnd().Replace("##Product", message.Product.Name).
                        Replace("##Description", message.Product.Description).
                        Replace("##Brand", message.Product.Brand).
                        Replace("##Price", message.Product.Price + "").
                        Replace("##Link", message.Content);
                }

                emailMessage.Body = builder.ToMessageBody();
            }
            else
            {
                emailMessage.Body = new TextPart("plain") { Text = message.Content };
            }
            return emailMessage;
        }
        private async Task SendAsync(MimeMessage mailMessage)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                    await client.DisconnectAsync(true);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    client.Dispose();
                }
            }
        }
    }
}
