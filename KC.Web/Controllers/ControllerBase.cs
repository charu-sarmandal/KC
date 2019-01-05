using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KC.Models;
using KC.ViewModels;
using KC.Data;
using KC.Web.ActionResults;
//using System.Web.Http;
using KC.Data.Repository;
using KC.Web.Utilities;

namespace KC.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public BetterJsonResult<T> BetterJson<T>(T model)
        {
            return new BetterJsonResult<T>() { Data = model };
        }
    }

    public class ControllerOptions
    {
        public string Type { get; set; }
        public string GridTitle { get; set; }
    }

    public class LoggedInUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }

    public abstract class KCGenericControllerBase<TModel, TForm, TVm> : ControllerBase
        where TModel : BaseModel where TForm : BaseForm where TVm : BaseVM, new()
    {
        public BaseRepository<TModel, TForm, TVm> repository;
        private ControllerOptions options;
        private LoggedInUser loggedInUser;
        public KCGenericControllerBase(BaseRepository<TModel, TForm, TVm> repository, ControllerOptions options)
        {
            this.repository = repository;
            this.options = options;

            this.loggedInUser = new LoggedInUser() { UserId = 1, UserName = "Sandeep", Role = "Admin" };
        }

        /* CRUD Methods*/

        

        protected virtual JsonResult AddBase(BaseAddForm form)
        {
            form.CreateById = loggedInUser.UserId;
            form.CreateDate = DateTime.UtcNow;
            var model = repository.InsertWithData(form);
            return BetterJson(model);
        }

        protected virtual JsonResult UpdateBase(BaseEditForm form)
        {
            form.UpdateById = loggedInUser.UserId;
            form.UpdateDate = DateTime.UtcNow;
            var model = repository.UpdateWithData(form);
            return BetterJson(model);
        }

        protected virtual JsonResult DeleteBase(BaseDeleteForm form)
        {
            form.DeleteById = loggedInUser.UserId;
            form.DeleteDate = DateTime.UtcNow;
            var model = repository.DeleteWithData(form);
            return BetterJson(model);
        }

        [HttpPost]
        public virtual JsonResult Get()
        {
            return GetData();            
        }

        public virtual JsonResult GetData(TForm form = null, bool enableCaching = true, List<string> condition = null)
        {
            var items = GetRowData(form, enableCaching, condition).ToArray();
            return BetterJson(items);
        }

        private List<TVm> GetRowData(TForm form = null, bool enableCaching = true, List<string> condition = null)
        {
            var items = repository.Get(form, enableCaching, condition);
            return items;
        }

        public virtual JsonResult GetById(int id)
        {
            var item = repository.GetById(id);
            return BetterJson(item);
        }

        public virtual JsonResult CheckNameExists(TForm form)
        {
            var result = repository.CheckNameExists(form);
            return BetterJson(result);
        }

        public ActionResult DownloadExcelFile()
        {
            var items = GetRowData();
            var data = items.ToExcelBytes(exclude:"Id", sheetName: this.options.Type);
            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", this.options.Type + ".xlsx");
        }
    }
}