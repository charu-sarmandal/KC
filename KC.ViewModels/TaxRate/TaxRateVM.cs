using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class TaxRateVM : BaseVM, IMapFrom<TaxRate>
	{
       public string Description { get; set; }
        public string Rate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}