using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Banksystem
    {
        public Banksystem()
        {
            Customersbanks = new HashSet<Customersbank>();
            Employeessystems = new HashSet<Employeessystem>();
        }

        public byte BranchId { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customersbank> Customersbanks { get; set; }
        public virtual ICollection<Employeessystem> Employeessystems { get; set; }
    }
}
