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
    public class HolidayController : KCGenericControllerBase<Holiday,BaseForm,HolidayVM>
    {
        public HolidayController():base(new HolidayRepository(), 
            new ControllerOptions() { Type = "Holiday", GridTitle = "Holiday Title" })
        {
            
        }

        public virtual JsonResult Add(HolidayAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(HolidayEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
