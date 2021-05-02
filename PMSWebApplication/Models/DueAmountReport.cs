using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class DueAmountReport
    {
        public int Id { get; set; }

        public DateTime? PayDate { get; set; }

        public int InvoiceNo { get; set; }

        //public string ClientName { get; set; }     

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        [Display(Name = "Paid Amount")]
        public decimal? PaidAmount { get; set; }
    }
}