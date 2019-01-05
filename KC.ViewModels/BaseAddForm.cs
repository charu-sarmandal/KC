using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace KC.ViewModels
{
	public abstract class BaseAddForm: BaseForm
	{        
        public DateTime CreateDate { get; set; }
        public int CreateById { get; set; }
        public bool IsDelete { get; set; }

    }
}