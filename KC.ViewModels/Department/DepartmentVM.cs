using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class DepartmentVM : BaseVM, IMapFrom<Department>
	{        
        public string Code { get; set; }
        public int NoOfEmpl { get; set; }
        public bool IsActive { get; set; }       
    }
}