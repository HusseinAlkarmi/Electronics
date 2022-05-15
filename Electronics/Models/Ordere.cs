using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Ordere
    {
        public decimal OrderId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? Sale { get; set; }
        public DateTime? OrdersDate { get; set; }

        public virtual Producte Product { get; set; }
        public virtual Usere User { get; set; }
    }
}
