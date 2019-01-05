using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace KC.ViewModels
{
	public abstract class BaseEditForm: BaseForm
	{        
        public DateTime UpdateDate { get; set; }        
        public int UpdateById { get; set; }
        
    }
}