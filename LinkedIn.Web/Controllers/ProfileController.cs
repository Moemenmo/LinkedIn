using Linkedin.Models.Entites;
using Linkedin.Models.Enum;
using LinkedIn.Core;
using LinkedIn.Core.Managers;
using LinkedIn.Web.Models.ProfileViewModels;
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
        //var CurrentUser;
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        public ProfileController()
        {
            System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        // GET: Profile
        public ActionResult Index()
        {
            ApplicationUser user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
            return View(user);
        }
        [HttpGet]
        public JsonResult GetWorkExp(Guid id)
        {
            var workExp = UnitOfWork.WorkExperienceManager.GetById(id);
            string s = "eshta";
            return Json(workExp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceViewModel workExpVM)
        {
            if (ModelState.IsValid)
            {
                workExpVM.Company.PlaceType = PlaceType.Company;
                UnitOfWork.SavedPlaceManager.Add(workExpVM.Company);
                WorkExperience workExp = new WorkExperience {
                                                            UserId = User.Identity.GetUserId(),
                                                            Title = workExpVM.Title,
                                                            Location = workExpVM.Location,
                                                            Description = workExpVM.Description,
                                                            EmploymentType = workExpVM.EmploymentType,
                                                            CompanyId = workExpVM.Company.Id,
                                                            StartDate = new DateTime(workExpVM.StartYear, workExpVM.StartMonth, 1)
                                                            };
                if(workExpVM.EndMonth != null && workExpVM.EndYear != null)
                {
                    workExp.EndDate = new DateTime((int)workExpVM.EndYear, (int)workExpVM.EndMonth, 1);
                }
                
                UnitOfWork.WorkExperienceManager.Add(workExp);
                return PartialView("__AddExperienceCard", workExp);
            }
           
            return View("Index");
        }

        [HttpGet]
        public ActionResult EditWorkExperience(Guid id)
        {
            WorkExperience wExp = UnitOfWork.WorkExperienceManager.GetById(id);
          
            WorkExperienceViewModel wExpVM = new WorkExperienceViewModel
            {
                //  UserId = User.Identity.GetUserId(),
                Title = wExp.Title,
                Location = wExp.Location,
                Description = wExp.Description,
                EmploymentType = wExp.EmploymentType,
                // CompanyId = wExp.Company.Id,
                //  StartDate = new DateTime(wExp.StartYear, wExp.StartMonth, 1)

            };
            return PartialView("_Experience",wExpVM);

        }
        [HttpPost]
        public ActionResult EditWorkExperience(WorkExperience wExp)
        {
            UnitOfWork.WorkExperienceManager.Update(wExp);
            ApplicationUser user = UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
            return RedirectToAction("index", user);

        }
        public ActionResult DeleteExperience(Guid id)
        {
            var w = UnitOfWork.WorkExperienceManager.GetAll();
            WorkExperience wExp = w.FirstOrDefault(x => x.Id == id);
            UnitOfWork.WorkExperienceManager.Delete(wExp);
            return RedirectToAction("index");
        }

    }
}