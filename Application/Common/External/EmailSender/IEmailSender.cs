using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.External.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(Email email);
    }
}
