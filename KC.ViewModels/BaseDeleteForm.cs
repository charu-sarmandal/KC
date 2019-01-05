using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace KC.ViewModels
{
	public class BaseDeleteForm: BaseForm
	{
        public BaseDeleteForm()
        {
            IsDelete = true;
        }
        public DateTime DeleteDate { get; set; }
        public int DeleteById { get; set; }
        public bool IsDelete { get; set; }

    }
}