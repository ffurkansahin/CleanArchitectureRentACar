using CleanArchitecture.Application.Services;
using GenericEmailService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> emails, string body,string subject, List<Attachment>? attachments)
        {
            EmailConfigurations configurations = new EmailConfigurations("smtp.gmail.com", "furkan33", 587, true, true);
            EmailModel<Attachment> sendEmailModel = new(configurations, "frknynsmr33@gmail.com", emails, subject, body, attachments);

            await EmailService.SendEmailWithNetAsync(sendEmailModel);
            
        }
    }
}
