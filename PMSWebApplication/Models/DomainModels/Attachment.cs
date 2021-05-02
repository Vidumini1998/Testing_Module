using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class Attachment
    {
        public Attachment()
        {
            BugFixes = new HashSet<BugFix>();
            Updates = new HashSet<Update>();
        }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BugFix> BugFixes { get; set; }
        public virtual ICollection<Update> Updates { get; set; }


    }
}
