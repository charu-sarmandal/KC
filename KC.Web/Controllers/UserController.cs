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
    public class UserController : KCGenericControllerBase<User,BaseForm,UserVM>
    {
        public UserController():base(new UserRepository(), 
            new ControllerOptions() { Type = "User", GridTitle = "User Title" })
        {
            
        }

        public virtual JsonResult Add(UserAddForm form)
        {
            return base.AddBase(form);
        }

        public virtual JsonResult Update(UserEditForm form)
        {
            return base.UpdateBase(form);
        }

        public virtual JsonResult Delete(BaseDeleteForm form)
        {
            return base.DeleteBase(form);
        }
    }
}
