using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Testimoniale
    {
        public decimal TestimonialId { get; set; }
        public string TestimonialText { get; set; }
        public decimal? UserId { get; set; }

        public virtual Usere User { get; set; }
    }
}
