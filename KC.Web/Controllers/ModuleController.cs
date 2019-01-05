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
    public class ModuleController : KCGenericControllerBase<Module,BaseForm,ModuleVM>
    {
        public ModuleController():base(new ModuleRepository(), 
            new ControllerOptions() { Type = "Module", GridTitle = "Module Title" })
        {
            
        }

        public virtual JsonResult Add(ModuleAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(ModuleEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
