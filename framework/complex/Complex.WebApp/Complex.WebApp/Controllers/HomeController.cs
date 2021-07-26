using Complex.Models;
using System.Web.Mvc;

namespace Complex.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AppHelper appHelper = new AppHelper();
            _ = appHelper.Add(1, 2);
            return View();
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
