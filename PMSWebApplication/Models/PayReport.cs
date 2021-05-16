using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class PayReport
    {
        public int Id { get; set; }

       
        public int ProjectId { get; set; }
        
       
        public int TaskId { get; set; }
       
        public string TaskStages { get; set; }

        
        public int InvoiceNo { get; set; }

        
        public DateTime? PayDate { get; set; }

        
        public decimal? PaymentAmount { get; set; }

        public string PayMethod { get; set; }

        public string PayDiscription { get; set; }
    }
}
