using LinkedIn.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class HomeController : Controller
    {

        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().get<UnitOfWork>();
            }
        }

        public ActionResult Index()
        {
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
        public ActionResult Search(string fname, string lname)
        {
            var user = UnitOfWork.ApplicationUserManager;
            var listOfUsers=user.getall
            return View();
        }
    }
}