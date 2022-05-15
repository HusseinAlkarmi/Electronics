using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Employee2
    {
        public int EmployeeId { get; set; }
        public string Employeename { get; set; }
        public decimal? Salary { get; set; }
        public int? ContactId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Contactinfo Contact { get; set; }
        public virtual Department Department { get; set; }
    }
}
