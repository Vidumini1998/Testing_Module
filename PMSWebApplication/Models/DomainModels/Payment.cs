using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSWebApplication.Models.DomainModels
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        [Required]
        [Display(Name = "Invoice No")]
        public int InvoiceNo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PayDate { get; set; }

        [Required]
       [Display(Name = "Pay Amount")]
        public decimal? PaymentAmount { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string PayMethod { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Description")]
        public string PayDiscription { get; set; }
    }
}
