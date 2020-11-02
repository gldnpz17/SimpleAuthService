using ApplicationDependencies.EmailSender;
using System;
using System.Net;
using System.Net.Mail;

namespace SMTPEmailSender
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _emailAddress;
        private string _emailPassword;
        private string _displayName;

        public SmtpEmailSender(
            string emailAddress,
            string emailPassword,
            string displayName
            )
        {
            _emailAddress = emailAddress;
            _emailPassword = emailPassword;
            _displayName = displayName;
        }

        public void SendEmail(Email email)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailAddress, _emailPassword)
            };

            using (var message = 
                new MailMessage(_emailAddress, email.Recipient) 
                { 
                    Subject = email.Subject, 
                    Body = email.Body,
                    IsBodyHtml = (email.EmailBodyType == EmailBodyType.HTML)
                })
            {
                smtpClient.Send(message);
            }
        }
    }
}
