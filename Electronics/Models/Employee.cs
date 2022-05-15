using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public int? PosId { get; set; }

        public virtual Position Pos { get; set; }
    }
}
