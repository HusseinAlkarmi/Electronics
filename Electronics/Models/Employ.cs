using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Employ
    {
        public int Employid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal? Salary { get; set; }
        public int? PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? DepartId { get; set; }

        public virtual Depart Depart { get; set; }
    }
}
