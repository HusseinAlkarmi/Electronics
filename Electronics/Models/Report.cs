using System;
using System.Collections.Generic;

#nullable disable

namespace Electronics.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public DateTime? ReportDate { get; set; }
        public int? EmployeeReportId { get; set; }
        public string EmployeeReportName { get; set; }
        public int? BankBranchNum { get; set; }

        public virtual Bank BankBranchNumNavigation { get; set; }
    }
}
