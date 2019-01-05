using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class ModuleEditForm : BaseEditForm, IMapTo<Module>
	{
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}