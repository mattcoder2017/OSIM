using OSIM.fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace Wrox.BooksRead.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View((User as ClaimsPrincipal).Claims);
        }

       [ResourceAuthorize(Fields.Read, Fields.WroxBooksRead)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       [ResourceAuthorize(Fields.Write, Fields.WroxBooksRead)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}