using Microsoft.Extensions.Options;
using Api.Helpers;
using System;
using System.Net;

namespace Api.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
    }
    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            // var email = new MimeMessage();
            // email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            // email.To.Add(MailboxAddress.Parse(to));
            // email.Subject = subject;
            // email.Body = new TextPart(TextFormat.Html) { Text = html };

            var email = new System.Net.Mail.MailMessage();
            email.From = new System.Net.Mail.MailAddress(from ?? _appSettings.EmailFrom);
            email.To.Add(to);
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Body = html;

            // send email
            try
            {
                var client = new System.Net.Mail.SmtpClient(_appSettings.SmtpHost, _appSettings.SmtpPort)
                {
                    Credentials = new NetworkCredential(_appSettings.SmtpUser, _appSettings.SmtpPass),
                    EnableSsl = true
                };
                // client.Send("from@example.com", "to@example.com", "Hello world", "testbody");
                client.Send(email);

                /*
                using var smtp = new SmtpClient();
                smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.Auto);
                smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
                smtp.Send(email);
                smtp.Disconnect(true);*/
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}