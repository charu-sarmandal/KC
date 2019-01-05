using System;
using System.Collections.Generic;

namespace KC.Models
{
	public abstract class BaseModel
    {		
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }        
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public int CreateById { get; set; }
        public int? UpdateById { get; set; }
        public int? DeleteByid { get; set; }

        public bool IsDelete { get; set; }
        public string SystemDescription { get; set; }

    }
}