using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class MaterialAddForm : BaseAddForm, IMapTo<Material>
	{
        public string Code { get; set; }
        public string Number { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
    }
}