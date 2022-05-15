using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Paymente
    {
        public decimal PayemntId { get; set; }
        public string Cardname { get; set; }
        public string Cardnum { get; set; }
        public decimal? Toalamount { get; set; }
        public DateTime Cardexp { get; set; }
        public decimal? UserId { get; set; }

        public virtual Usere User { get; set; }
    }
}
