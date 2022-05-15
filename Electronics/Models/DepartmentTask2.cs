using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class DepartmentTask2
    {
        public DepartmentTask2()
        {
            EmployeeTask2s = new HashSet<EmployeeTask2>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<EmployeeTask2> EmployeeTask2s { get; set; }
    }
}
