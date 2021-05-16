using System;

namespace PMSWebApplication.Models
{
    public class UpcomingPaymentReport
    {
        public int Id { get; set; }

        public DateTime? Deadline { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public string TaskStages { get; set; }

        public string ClientName { get; set; }

        public string ContactNo { get; set; }

        public decimal? TotalPayment { get; set; }

        public decimal? PaidAmount { get; set; }

        public decimal? Balance { get; set; }

    }
}