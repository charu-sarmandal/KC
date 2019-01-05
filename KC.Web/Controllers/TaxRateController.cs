using KC.Data.Repository;
using KC.Models;
using KC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KC.Web.Controllers
{
    public class TaxRateController : KCGenericControllerBase<TaxRate,BaseForm,TaxRateVM>
    {
        public TaxRateController():base(new TaxRateRepository(), 
            new ControllerOptions() { Type = "TaxRate", GridTitle = "TaxRate Title" })
        {
            
        }

        public virtual JsonResult Add(TaxRateAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(TaxRateEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
