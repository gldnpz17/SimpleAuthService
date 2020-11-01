using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface ITotpVerifierService
    {
        bool TotpIsValid(string token, DateTime tokenTime, string sharedSecret, IDateTimeService dateTimeService);
    }
}
