using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Electronics.Models
{
    public partial class Homepagee
    {
        public Homepagee()
        {
            Aboutes = new HashSet<Aboute>();
            Contactes = new HashSet<Contacte>();
        }

        public decimal HomeId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Image4 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
        public string Text7 { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual ICollection<Aboute> Aboutes { get; set; }
        public virtual ICollection<Contacte> Contactes { get; set; }
    }
}
