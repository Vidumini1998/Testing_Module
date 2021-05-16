using System;

namespace PMSWebApplication.Models
{
    public class TaskStatusReport
    {
        public int Id { get; set; }

        public DateTime? Deadline { get; set; }

        public string ClientName { get; set; }

        public string ProjectName { get; set; }

        public string EmployeeName { get; set; }

        public string TaskName { get; set; }

        public string TaskStatus { get; set; }         
    }
}