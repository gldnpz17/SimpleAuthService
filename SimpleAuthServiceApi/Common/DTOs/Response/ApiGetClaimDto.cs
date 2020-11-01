using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.DTOs.Response
{
    public class ApiGetClaimDto
    {
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}
