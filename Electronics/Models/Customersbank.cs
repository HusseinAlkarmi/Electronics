using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Customersbank
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? AccountId { get; set; }
        public int? Balance { get; set; }
        public byte? BranchId { get; set; }

        public virtual Banksystem Branch { get; set; }
    }
}
