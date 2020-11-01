using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDependencies.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
}
