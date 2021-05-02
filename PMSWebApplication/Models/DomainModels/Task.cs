using System;
using System.Collections.Generic;



namespace PMSWebApplication.Models.DomainModels
{
    public class Task
    {
        public Task()
        {
            Payments = new HashSet<Payment>();
            EmployeeAssignments = new HashSet<EmployeeAssignment>();
        }
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string TaskStatus { get; set; }
        public string TaskStages { get; set; }
        public decimal? TaskWisePayment { get; set; }
        public DateTime? SDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? EDate { get; set; }
        public string AssignedEmployee { get; set; }
        public string TaskDescription { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<EmployeeAssignment> EmployeeAssignments { get; set; }

    }
}
