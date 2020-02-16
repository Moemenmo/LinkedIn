using LinkedIn.Core;
using Microsoft.AspNet.Identity.Owin;
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
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
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
            var listOfUsers = user.Users.Where(e => e.FirstName.Contains(fname) || 
            e.FirstName.StartsWith(fname) ||
            e.FirstName.EndsWith(fname)).ToList();
            listOfUsers.AddRange(user.Users.Where(e => e.LastName.Contains(lname) ||
            e.LastName.StartsWith(lname) ||
            e.LastName.EndsWith(lname)));
            return View();
        }
    }
}