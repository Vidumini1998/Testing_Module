using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class Employee : ApplicationUser
    {
        public string Comment { get; set; }
        public string Image { get; set; }
        public string HomeContactNo { get; set; }
        public string Nic { get; set; }
    }
}
