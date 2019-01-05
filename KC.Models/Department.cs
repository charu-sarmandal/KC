using System;
using System.Collections.Generic;

namespace KC.Models
{
	public class Department:BaseModel
	{
		public string Code { get; set; }
        public string NoOfEmpl { get; set; }
       	public bool IsActive { get; set; }
    }
}