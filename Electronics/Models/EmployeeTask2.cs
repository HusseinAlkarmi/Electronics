using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class EmployeeTask2
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public int? PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }

        public virtual DepartmentTask2 Department { get; set; }
    }
}
