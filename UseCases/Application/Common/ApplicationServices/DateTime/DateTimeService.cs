using Domain.Services;
using System;

namespace Application.Common.ApplicationServices.DateTime
{
    public class DateTimeService : IDateTimeService
    {
        public System.DateTime GetCurrentDateTime()
        {
            return System.DateTime.Now;
        }
    }
}
