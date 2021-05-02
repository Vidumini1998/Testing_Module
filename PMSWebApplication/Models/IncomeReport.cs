using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSWebApplication.Models
{
    public class IncomeReport
    {
        public decimal? Revenue { get; set; }

        public decimal? Expences { get; set; }

        public decimal? NetIncome { get; set; }
    }
}