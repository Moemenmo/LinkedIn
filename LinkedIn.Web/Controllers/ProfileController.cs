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
            WorkExperience workExp = UnitOfWork.WorkExperienceManager.GetById(id);
            string[] startDate = workExp.StartDate.ToString("MMMM dd yyyy").Split(' ');
            string startMonth = startDate[0];
            string startYear = startDate[2];
            string endMonth = "", endYear = "";
            workExp.IsPresent = true;
            if (workExp.EndDate != null)
            {
                string[] endDate = workExp.EndDate.Value.ToString("MMMM dd yyyy").Split(' ');
                endMonth = endDate[0];
                endYear = endDate[2];
                workExp.IsPresent = false;
            }
            return Json(new
            {
                Title = workExp.Title,
                EmploymentType = workExp.EmploymentType,
                Location = workExp.Location,
                Description = workExp.Description,
                StartMonth = startMonth,
                StartYear = startYear,
                EndMonth = endMonth,
                EndYear = endYear,
                IsPresent = workExp.IsPresent
            },JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult EditWorkExperience(WorkExperienceViewModel workExpVM)
        {
            if (ModelState.IsValid)
            {
                workExpVM.Company.PlaceType = PlaceType.Company;
                UnitOfWork.SavedPlaceManager.Add(workExpVM.Company);
                WorkExperience workExp = new WorkExperience
                {
                    Id = workExpVM.Id,
                    UserId = User.Identity.GetUserId(),
                    Title = workExpVM.Title,
                    Location = workExpVM.Location,
                    Description = workExpVM.Description,
                    EmploymentType = workExpVM.EmploymentType,
                    CompanyId = workExpVM.Company.Id,
                    StartDate = new DateTime(workExpVM.StartYear, workExpVM.StartMonth, 1)
                };
                if (workExpVM.EndMonth != null && workExpVM.EndYear != null)
                {
                    workExp.EndDate = new DateTime((int)workExpVM.EndYear, (int)workExpVM.EndMonth, 1);
                }

                UnitOfWork.WorkExperienceManager.Update(workExp);
                return PartialView("__AddExperienceCard", workExp);
            }

            return View("Index");
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