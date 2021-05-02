using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSWebApplication.Models.DomainModels
{
    public class Project
    {
        public Project()
        {
            Attachments = new HashSet<Attachment>();
            Tasks = new HashSet<Task>();
            PriorityLists = new HashSet<PriorityList>();
            Bugfixes = new HashSet<BugFix>();
            Updates = new HashSet<Update>();
            Payments = new HashSet<Payment>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Description")]
        public string ProjectDescription { get; set; }

        [Display(Name = "Stages")]
        public int? NoOfStages { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EDate { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<PriorityList> PriorityLists { get; set; }
        public virtual ICollection<BugFix> Bugfixes { get; set; }
        public virtual ICollection<Update> Updates { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

    }
}
