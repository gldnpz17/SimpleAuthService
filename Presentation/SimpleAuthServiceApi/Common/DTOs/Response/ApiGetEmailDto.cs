using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Response
{
    public class ApiGetEmailDto
    {
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
    }
}
