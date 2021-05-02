using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class EmployeeAssignment
    {
        public int Id { get; set; }
        public string EmployeeEmail { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public string Comment { get; set; }
    }
}
