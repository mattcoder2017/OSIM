using DevTrends.MvcDonutCaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wrox.BooksRead.Web.Controllers
{
    public class HomeController : Controller
    {
        [DonutOutputCache(Duration = int.MaxValue, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "none")]
        //[DonutOutputCache(Duration = 24 * 3600)]
        public ActionResult Index()
        {
            var mgr = new OutputCacheManager();
            mgr.RemoveItem("Home", "LoginPartial");
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

        [ChildActionOnly DonutOutputCache(Duration =0, Options = OutputCacheOptions.ReplaceDonutsInChildActions)]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}