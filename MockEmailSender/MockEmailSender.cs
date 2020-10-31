using ApplicationDependencies.EmailSender;
using System.Diagnostics;

namespace MockEmailSender
{
    public class MockEmailSender : IEmailSender
    {
        public void SendEmail(Email email)
        {
            Debug.WriteLine($"Email sent. Recipient:{email.Recipient}; Subject:{email.Subject}; BodyType:{email.EmailBodyType}; Body:{email.Body}");
        }
    }
}
