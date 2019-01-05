using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class DepartmentEditForm : BaseEditForm, IMapTo<Department>
	{
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}