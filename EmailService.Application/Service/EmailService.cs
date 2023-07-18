using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Application.DTOs;
using EmailService.Application.Interface;
using System.Net.Mail;
using System.Net;

namespace EmailService.Application.Service
{
    public class SendEmailService : IEmailService
    {
        public string SendEmail(EmailDTO model)
        {
            var email = Environment.GetEnvironmentVariable("EMAIL");
            var password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            var emailName = Environment.GetEnvironmentVariable("EMAIL_NAME");
            var smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
            var smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT");

            MailMessage emailMessage = new MailMessage();
            try
            {
                var smtpClient = new SmtpClient(smtpServer, 587);
                smtpClient.Timeout = 30000;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(email, password);
                emailMessage.From = new MailAddress(email, emailName);
                emailMessage.IsBodyHtml = true;
                
                emailMessage.Priority = MailPriority.Normal;
                emailMessage.Body = model.Content;
                emailMessage.Subject = model.Subject;
                emailMessage.To.Add(model.Addressee);
                smtpClient.Send(emailMessage);
                return "Email enviado com sucesso!";
            }
            catch(Exception ex)
            {
                return $"Erro ao enviar o email. Erro: {ex.Message}";
            }
        }
    }
}