using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Userlogin
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Cust Customer { get; set; }
    }
}
