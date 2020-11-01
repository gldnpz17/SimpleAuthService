using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Request
{
    public class ApiVerifyEmailDto
    {
        public string VerificationCode { get; set; }
    }
}
