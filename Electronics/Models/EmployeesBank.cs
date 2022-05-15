using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class EmployeesBank
    {
        public short EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public byte? Salary { get; set; }
        public byte? BankBranchId { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public virtual BankJordan BankBranch { get; set; }
    }
}
