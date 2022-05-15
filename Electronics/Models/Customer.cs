using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Customer
    {
        public string CustomerName { get; set; }
        public int? BankAcountNum { get; set; }
        public decimal? Balance { get; set; }
        public int? PhoneNum { get; set; }
        public int? BankBranchNum { get; set; }
        public int Id { get; set; }

        public virtual Bank BankBranchNumNavigation { get; set; }
    }
}
