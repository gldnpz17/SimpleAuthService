using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Response
{
    public class ApiGetAccountDto
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
    }
}
