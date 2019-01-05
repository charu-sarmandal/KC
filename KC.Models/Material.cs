using System;
using System.Collections.Generic;

namespace KC.Models
{
	public class Material:BaseModel
    {
        public string Code { get; set; }
        public string Number { get; set; }
        public string UnitOfMeasure { get; set; }

    }
}