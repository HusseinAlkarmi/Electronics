using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Employ2
    {
        public int EmployId { get; set; }
        public string EmployName { get; set; }
        public decimal? Salary { get; set; }
        public int? ContactId { get; set; }
        public int? DepartId { get; set; }

        public virtual Contactinfo2 Contact { get; set; }
        public virtual Depart2 Depart { get; set; }
    }
}
