using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action used to deliver the entry point for AngularJS App
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Todo App";

            return View();
        }
    }
}
