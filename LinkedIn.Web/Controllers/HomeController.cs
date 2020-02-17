using Linkedin.Models.Entites;
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
            List<ApplicationUser> listOfUsers = user.Users.Where(e => (fname.Length > 0 && e.FirstName.Contains(fname))
                                                  ||(lname.Length > 0 && e.LastName.Contains(lname))).ToList();
           
            //if (fname != "" && lname != "")
            //{
            //    listOfUsers = user.Users.Where(e => e.FirstName.Contains(fname)
            //                                        || e.FirstName.StartsWith(fname)
            //                                        || e.FirstName.EndsWith(fname)
            //                                        || e.LastName.Contains(lname)
            //                                        || e.LastName.StartsWith(lname)
            //                                        || e.LastName.EndsWith(lname)).ToList();
            //}
            //else if (fname != "")
            //{
            //    var listOfUsers = user.Users.Where(e => e.FirstName.Contains(fname)
            //                                    || e.FirstName.StartsWith(fname)
            //                                    || e.FirstName.EndsWith(fname)).ToList();
            //}
            //else if (lname != "")
            //{
            //    var listOfUsers = user.Users.Where(e => e.LastName.Contains(lname) ||
            //                                       e.LastName.StartsWith(lname) ||
            //                                       e.LastName.EndsWith(lname)).ToList();
            //}
            //else
            //{
            //    var listOfUsers = false;
            //}
            //foreach (var e in user.Users)
            //{
            //    bool test = e.FirstName.Contains(fname);
            //    test = e.FirstName.StartsWith(fname);
            //    test = e.FirstName.EndsWith(fname);
            //    test = e.LastName.Contains(lname);
            //    test = e.LastName.StartsWith(lname);
            //    test = e.LastName.EndsWith(lname);
            //}
            //listOfUsers.AddRange(user.Users.Where(e => e.LastName.Contains(lname) ||
            //                                       e.LastName.StartsWith(lname) ||
            //                                       e.LastName.EndsWith(lname)));
            return View(listOfUsers);
        }
    }
}