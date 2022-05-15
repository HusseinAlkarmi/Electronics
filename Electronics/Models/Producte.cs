using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Electronics.Models
{
    public partial class Producte
    {
        public Producte()
        {
            Orderes = new HashSet<Ordere>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Quntity { get; set; }
        public decimal? Sale { get; set; }
        public decimal? Cost { get; set; }
        public string Image { get; set; }
        public decimal? CategoryId { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual Categorye Category { get; set; }
        public virtual ICollection<Ordere> Orderes { get; set; }
    }
}
