using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class PriorityReport
    {
        public int Id { get; set; }

        public DateTime? Deadline { get; set; }

        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public int? PriorityNo { get; set; }
    }
}