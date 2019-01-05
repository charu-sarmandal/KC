using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class UserAddForm : BaseAddForm, IMapTo<User>
	{        
        public string Name { get; set; }        
        public string WorkEmail { get; set; }
        public int Age { get; set; }
        

    }
}