using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class BankJordan
    {
        public BankJordan()
        {
            EmployeesBanks = new HashSet<EmployeesBank>();
        }

        public byte BankBranchId { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }

        public virtual ICollection<EmployeesBank> EmployeesBanks { get; set; }
    }
}
