using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Depart2
    {
        public Depart2()
        {
            Employ2s = new HashSet<Employ2>();
        }

        public int DepartId { get; set; }
        public string DepartName { get; set; }
        public int? AddressId { get; set; }

        public virtual Address2 Address { get; set; }
        public virtual ICollection<Employ2> Employ2s { get; set; }
    }
}
