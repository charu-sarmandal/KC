using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class RoleVM : BaseVM, IMapFrom<Role>
	{
        public bool IsActive { get; set; }
    }
}