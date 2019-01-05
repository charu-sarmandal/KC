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
    public class HomeController : KCGenericControllerBase<User,BaseForm,UserVM>
    {
        public HomeController():base(new UserRepository(), 
            new ControllerOptions() { Type = "User", GridTitle = "User Title" })
        {
            
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();

            var userRepo = new UserRepository();
            var data = userRepo.Get();

            var userInsert = new UserAddForm()
            {
                Name = "Sandeep",
                Age = 35,
                WorkEmail = "sandeep@s.com",
                CreateDate = DateTime.UtcNow,
                CreateById = 0,
                IsDelete = false
            };
            var dataInsert = userRepo.InsertWithData(userInsert);

            var data1 = userRepo.Get(null);

            var userUpdate = new UserEditForm()
            {
                Age = 35,
                WorkEmail = "sandeep@s.com",
                Id = 1,
                UpdateById = 0,
                UpdateDate = DateTime.Now
            };
            var dataUpdate = userRepo.UpdateWithData(userUpdate);
            var data2 = userRepo.Get(null);

            var userDelete = new BaseDeleteForm()
            {
                Id = 1,
                DeleteById = 0,
                DeleteDate = DateTime.Now,
                IsDelete = true
            };
            var dataDelete = userRepo.UpdateWithData(userDelete);
            var data3 = userRepo.Get(null);



            return View();
        }

        //public virtual JsonResult GetData()
        //{
        //    return base.GetDataDB();            
        //}
    }
}
