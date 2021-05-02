using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime? LoginDate { get; set; }
        public TimeSpan? LoginTime { get; set; }
        public TimeSpan? LogoutTime { get; set; }
    }
}
