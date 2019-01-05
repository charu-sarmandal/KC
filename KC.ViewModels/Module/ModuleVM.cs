using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class ModuleVM : BaseVM, IMapFrom<Module>
	{        
        public bool IsActive { get; set; }
    }
}