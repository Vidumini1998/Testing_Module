using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class Client : ApplicationUser
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactNo { get; set; }
    }
}
