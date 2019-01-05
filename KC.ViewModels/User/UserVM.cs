using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KC.Models;

namespace KC.ViewModels
{
	public class UserVM : BaseVM, IMapFrom<User>
	{
        //public string Name { get; set; }
        public string WorkEmail { get; set; }
        public int Age { get; set; }
        //public string Code { get; set; }
    }
}