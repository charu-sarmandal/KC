using System;
using System.Collections.Generic;

namespace KC.Models
{
	public class User:BaseModel
	{
		public string WorkEmail { get; set; }
        public int Age { get; set; }
       	
    }
}