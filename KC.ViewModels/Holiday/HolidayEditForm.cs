using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class HolidayEditForm : BaseEditForm, IMapTo<Holiday>
	{
        public string Occassion { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
    }
}