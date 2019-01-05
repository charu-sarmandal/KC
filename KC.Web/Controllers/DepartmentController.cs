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
    public class DepartmentController : KCGenericControllerBase<Department,BaseForm,DepartmentVM>
    {
        public DepartmentController():base(new DepartmentRepository(), 
            new ControllerOptions() { Type = "Department", GridTitle = "Department Title" })
        {
            
        }

        public virtual JsonResult Add(DepartmentAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(DepartmentEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
