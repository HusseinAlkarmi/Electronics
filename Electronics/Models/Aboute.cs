using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Aboute
    {
        public decimal AboutId { get; set; }
        public string Text1 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Text3 { get; set; }
        public decimal? HomeId { get; set; }

        public virtual Homepagee Home { get; set; }
    }
}
