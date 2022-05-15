using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Address2
    {
        public Address2()
        {
            Contactinfo2s = new HashSet<Contactinfo2>();
            Depart2s = new HashSet<Depart2>();
        }

        public int AddressId { get; set; }
        public string AddressName { get; set; }

        public virtual ICollection<Contactinfo2> Contactinfo2s { get; set; }
        public virtual ICollection<Depart2> Depart2s { get; set; }
    }
}
