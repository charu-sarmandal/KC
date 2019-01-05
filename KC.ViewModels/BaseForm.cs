using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace KC.ViewModels
{
	public abstract class BaseForm
	{
		[HiddenInput]
		public int Id { get; set; }

		
	}
}