using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PosId { get; set; }
        public string PosName { get; set; }
        public int? BankBranchNum { get; set; }

        public virtual Bank BankBranchNumNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
