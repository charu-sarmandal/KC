using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
	public class HolidayAddForm : BaseAddForm, IMapTo<Holiday>
	{
        public string Occassion { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
    }
}