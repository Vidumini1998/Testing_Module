using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class BugFix
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        public string Comment { get; set; }
    }
}
