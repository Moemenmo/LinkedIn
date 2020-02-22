using Linkedin.Models.Entites;
using LinkedIn.Core;
using LinkedIn.Core.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class ProfileController : Controller
    {
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        // GET: Profile
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperience workExp)
        {
            //Just For Debugging
            if (ModelState.IsValid)
            {

                UnitOfWork.WorkExperienceManager.Add(workExp);
            }
           
            return PartialView("_Experience");
        }

    }
}