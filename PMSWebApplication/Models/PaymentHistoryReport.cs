using System;

namespace PMSWebApplication.Models
{
    public class PaymentHistoryReport
    {
        public int Id { get; set; }

        public DateTime? PayDate { get; set; }

        public int InvoiceNo { get; set; }

        public string ProjectName { get; set; }
      
        public string TaskName { get; set; }
       
        public string PayMethod { get; set; }

        public string Description { get; set; }

        public decimal? PaymentAmount { get; set; }

    }
}