using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Contactinfo
    {
        public Contactinfo()
        {
            Employee2s = new HashSet<Employee2>();
        }

        public int ContactId { get; set; }
        public int? Phonenumber { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Employee2> Employee2s { get; set; }
    }
}
