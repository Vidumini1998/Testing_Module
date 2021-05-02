using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class PriorityList
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? PriorityNo { get; set; }
    }
}
