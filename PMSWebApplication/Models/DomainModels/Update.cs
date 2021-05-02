using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSWebApplication.Models.DomainModels
{
    public class Update
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Deadline")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Deadline { get; set; }
    }
}
