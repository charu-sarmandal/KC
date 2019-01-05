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
    public class RoleController : KCGenericControllerBase<Role,BaseForm,RoleVM>
    {
        public RoleController():base(new RoleRepository(), 
            new ControllerOptions() { Type = "Role", GridTitle = "Role Title" })
        {
            
        }

        public virtual JsonResult Add(RoleAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(RoleEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
