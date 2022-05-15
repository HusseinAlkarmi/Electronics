using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Rolee
    {
        public Rolee()
        {
            Loginandreges = new HashSet<Loginandrege>();
            Useres = new HashSet<Usere>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Loginandrege> Loginandreges { get; set; }
        public virtual ICollection<Usere> Useres { get; set; }
    }
}
