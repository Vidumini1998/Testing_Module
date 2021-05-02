using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class UpcommingPayment
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public decimal? Payment { get; set; }

        public DateTime? Deadline { get; set; }
    }
}