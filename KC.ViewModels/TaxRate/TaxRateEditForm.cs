using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KC.Models;

namespace KC.ViewModels
{
    public class TaxRateEditForm : BaseEditForm, IMapTo<TaxRate>
    {
        public string Description { get; set; }
        public string Rate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}