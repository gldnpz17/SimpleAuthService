using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Claim
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
