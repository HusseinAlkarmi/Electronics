using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee2s = new HashSet<Employee2>();
        }

        public int DepartmentId { get; set; }
        public string Departmentname { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Employee2> Employee2s { get; set; }
    }
}
