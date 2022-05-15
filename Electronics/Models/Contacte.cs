using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Contacte
    {
        public decimal ContId { get; set; }
        public string Name { get; set; }
        public decimal? Age { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public decimal? HomeId { get; set; }

        public virtual Homepagee Home { get; set; }
    }
}
