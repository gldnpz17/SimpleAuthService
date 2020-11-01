using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDomainServices
{
    class MockDateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.MinValue;
        }
    }
}
