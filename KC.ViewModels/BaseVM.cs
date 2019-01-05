using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KC.ViewModels
{
	public abstract class BaseVM
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

    }
}