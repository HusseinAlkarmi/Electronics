using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Reviewe
    {
        public decimal ReviewId { get; set; }
        public decimal? UserId { get; set; }
        public decimal Rating { get; set; }
        public string Message { get; set; }

        public virtual Usere User { get; set; }
    }
}
