﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using MimeKit;

namespace EmailSender
{
        public class Message
        {
            public List<MailboxAddress> To { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
            public Product? Product { get; set; }
            public string Customer { get; set; }

            public Message(IEnumerable<string> to, string subject, string content, Product product, string customer)
            {
                To = new List<MailboxAddress>();
                To.AddRange(to.Select(x => new MailboxAddress(x, x)));
                Subject = subject;
                Content = content;
                Product = product;
                Customer = customer;
            }
        }
}
