using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Employeessystem
    {
        public Employeessystem()
        {
            RoleBanks = new HashSet<RoleBank>();
        }

        public short EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public byte? Salary { get; set; }
        public byte? BranchId { get; set; }

        public virtual Banksystem Branch { get; set; }
        public virtual ICollection<RoleBank> RoleBanks { get; set; }
    }
}
