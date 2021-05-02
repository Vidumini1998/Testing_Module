using System;
using System.Collections.Generic;

namespace PMSWebApplication.Models.DomainModels
{
    public class Contact
    {
        public int Id { get; set; }

        public string ContactNo { get; set; }
        public string ClientEmail { get; set; }
        public string ContactName { get; set; }
    }
}
