using System;
using System.Collections.Generic;

namespace KC.Models
{
    public class TaxRate : BaseModel
    {
        public string TaxDescription { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
    }
}