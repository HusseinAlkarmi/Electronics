using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Electronics.Models
{
    public partial class Usere
    {
        public Usere()
        {
            Orderes = new HashSet<Ordere>();
            Paymentes = new HashSet<Paymente>();
            Reviewes = new HashSet<Reviewe>();
            Testimoniales = new HashSet<Testimoniale>();
        }

        public decimal UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public decimal? Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal? RoleId { get; set; }
        //public decimal? LogId { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string Image { get; set; }

        
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        //public virtual Loginandrege Log { get; set; }
        public virtual Rolee Role { get; set; }
        public virtual ICollection<Ordere> Orderes { get; set; }
        public virtual ICollection<Paymente> Paymentes { get; set; }
        public virtual ICollection<Reviewe> Reviewes { get; set; }
        public virtual ICollection<Testimoniale> Testimoniales { get; set; }
    }
}
