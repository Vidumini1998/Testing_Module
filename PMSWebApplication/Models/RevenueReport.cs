using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class RevenueReport
    {
        public int Id { get; set; }

        public DateTime? PayDate { get; set; }

        public int InvoiceNo { get; set; }

        public string ProjectName { get; set; }

        //public string ClientName { get; set; }

        public string PaymentMethod { get; set; }

        public string Description { get; set; }

        public decimal? PaymentAmount { get; set; }

    }
}