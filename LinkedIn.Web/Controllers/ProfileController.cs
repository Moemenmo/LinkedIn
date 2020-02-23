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

            return View();
        }
        [HttpPost]
        public ActionResult AddWorkExperience(WorkExperienceViewModel workExpVM)
        {
            if (ModelState.IsValid)
            {
                //int x = User.Identity.GetUserId;
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
            }
           
            return PartialView("_Experience");
        }

    }
}