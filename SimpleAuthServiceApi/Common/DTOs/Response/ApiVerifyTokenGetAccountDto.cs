using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceApi.Common.DTOs.Response
{
    public class ApiVerifyTokenGetAccountDto
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
    }
}
