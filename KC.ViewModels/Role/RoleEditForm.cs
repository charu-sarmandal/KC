using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class RoleEditForm : BaseEditForm, IMapTo<Role>
	{
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}