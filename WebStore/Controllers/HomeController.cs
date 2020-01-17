using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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