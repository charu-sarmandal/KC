using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class MaterialVM : BaseVM, IMapFrom<Material>
	{        
        public string Code { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}