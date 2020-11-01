using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Configuration
{
    internal class ApplicationConfiguration
    {
        public int MaxUsernameLength { get; set; }

        public int MinPasswordLength { get; set; }
        public int MaxPasswordLength { get; set; }
    }
}
