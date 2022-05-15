using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Electronics.Models
{
    public partial class Loginandrege
    {
        //public Loginandrege()
        //{
        //    Useres = new HashSet<Usere>();
        //}

        public decimal LogId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual Rolee Role { get; set; }
        //public virtual ICollection<Usere> Useres { get; set; }
    }
}
