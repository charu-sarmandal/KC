using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class HolidayVM : BaseVM, IMapFrom<Holiday>
	{        
        public string Occassion { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
    }
}