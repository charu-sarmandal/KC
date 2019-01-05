using System;
using System.Collections.Generic;

namespace KC.Models
{
	public class Holiday:BaseModel
    {
        public string Occassion { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }

    }
}