using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Depart
    {
        public Depart()
        {
            Employs = new HashSet<Employ>();
        }

        public int DepartId { get; set; }
        public string DepartName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employ> Employs { get; set; }
    }
}
