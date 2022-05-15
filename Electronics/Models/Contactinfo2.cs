using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Contactinfo2
    {
        public Contactinfo2()
        {
            Employ2s = new HashSet<Employ2>();
        }

        public int ContactId { get; set; }
        public int? PhoneNumber { get; set; }
        public int? AddressId { get; set; }

        public virtual Address2 Address { get; set; }
        public virtual ICollection<Employ2> Employ2s { get; set; }
    }
}
