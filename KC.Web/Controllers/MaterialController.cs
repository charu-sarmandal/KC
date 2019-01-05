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
    public class MaterialController : KCGenericControllerBase<Material,BaseForm,MaterialVM>
    {
        public MaterialController():base(new MaterialRepository(), 
            new ControllerOptions() { Type = "Material", GridTitle = "Material Title" })
        {
            
        }

        public virtual JsonResult Add(MaterialAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(MaterialEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
