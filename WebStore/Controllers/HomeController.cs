using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            workerModel workerModelView = new workerModel();
            workerModelView = workerModelView.returnWorkerID();

            return View();
        }
        [HttpPost]
        public JsonResult GetAccount(workerModel workerModelView)
        {
            workerModelView.isvalid = true;
            bool result = workerModelView.LoginStatus(workerModelView);
            if (result)
            {
                return Json(new { status = result, message = "Success!", url = Url.Action("_details", "Home") });
            }
            else
            {
                workerModelView.isvalid = false;
                return Json(new { status = result, message = "Failed!", url = Url.Action("_FailLogin", "Home") });
            }
        }
        public ActionResult _details()
        {
            workerModel workerModelView = new workerModel();
            return PartialView("_details", workerModelView);
        }
        public ActionResult _FailLogin()
        {
            return View();
        }

    }
}