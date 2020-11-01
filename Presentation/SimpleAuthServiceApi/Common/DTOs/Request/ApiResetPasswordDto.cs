using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Request
{
    public class ApiResetPasswordDto
    {
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
