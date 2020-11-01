using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Request
{
    public class ApiPasswordLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
