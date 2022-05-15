using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Audits2
    {
        public decimal AuditId { get; set; }
        public string Tablename { get; set; }
        public string Transactionname { get; set; }
        public string Byuser { get; set; }
        public DateTime? Transactiondate { get; set; }
    }
}
