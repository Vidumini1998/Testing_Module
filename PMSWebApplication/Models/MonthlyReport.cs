using System;

namespace PMSWebApplication.Models
{
    public class MonthlyReport
    {
        public int Id { get; set; }

        public DateTime? Deadline { get; set; }

        public string ProjectName { get; set; }

        public string ClientName { get; set; }

        public string BugFixes { get; set; }

        public string ProjectStatus { get; set; }

        public decimal? TotalPayment { get; set; }

    }
}