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
            List<workerModel> test = new List<workerModel>();

            test = workerModelView.getAccounts();
            return PartialView("_details", workerModelView);
        }
        [HttpPost]
        public JsonResult GetAccount(workerModel workerModelView)
        {
            var model = workerModelView;
            return Json(new { Data = model }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}