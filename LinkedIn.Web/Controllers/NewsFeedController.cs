using Linkedin.Models.Entites;
using LinkedIn.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class NewsFeedController : Controller
    {
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        public ApplicationUser loginuser
        {
            get
            {
                    
                    return UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
    
            }
        }


        // GET: NewsFeed
        [HttpGet]
        public ActionResult Index()
        {
            return View(loginuser);
        }
    }
}