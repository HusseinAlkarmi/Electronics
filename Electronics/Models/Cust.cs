using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Cust
    {
        public Cust()
        {
            Productcustomers = new HashSet<Productcustomer>();
            Userlogins = new HashSet<Userlogin>();
        }

        public decimal Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Imagepath { get; set; }

        public virtual ICollection<Productcustomer> Productcustomers { get; set; }
        public virtual ICollection<Userlogin> Userlogins { get; set; }
    }
}
