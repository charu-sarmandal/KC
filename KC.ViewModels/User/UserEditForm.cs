using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class UserEditForm : BaseEditForm, IMapTo<User>
	{       
        public string WorkEmail { get; set; }
        public int Age { get; set; }
    }
}