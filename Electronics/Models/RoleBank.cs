using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class RoleBank
    {
        public byte RoleId { get; set; }
        public string RoleName { get; set; }
        public short? EmployeeId { get; set; }

        public virtual Employeessystem Employee { get; set; }
    }
}
