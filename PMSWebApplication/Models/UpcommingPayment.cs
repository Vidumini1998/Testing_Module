using System;

namespace PMSWebApplication.Models
{
    public class UpcommingPayment
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public string TaskStages { get; set; }

        public decimal? Payment { get; set; }

        public DateTime? Deadline { get; set; }
    }
}