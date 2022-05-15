using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Electronics.Models
{
    public partial class Categorye
    {
        public Categorye()
        {
            Productes = new HashSet<Producte>();
        }

        public decimal CategoryId { get; set; }
        public string Categoryname { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual ICollection<Producte> Productes { get; set; }
    }
}
