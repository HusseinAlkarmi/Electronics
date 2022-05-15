using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Address
    {
        public Address()
        {
            Contactinfos = new HashSet<Contactinfo>();
            Departments = new HashSet<Department>();
        }

        public int AddressId { get; set; }
        public string Addressname { get; set; }

        public virtual ICollection<Contactinfo> Contactinfos { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
