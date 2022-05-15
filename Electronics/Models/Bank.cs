using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Customers = new HashSet<Customer>();
            Positions = new HashSet<Position>();
            Reports = new HashSet<Report>();
        }

        public int BankBranchNum { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
