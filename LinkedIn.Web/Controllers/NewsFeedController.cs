using Linkedin.DbContext;
using Linkedin.Models.Entites;
using LinkedIn.Core;
using LinkedIn.Core.Managers;
using LinkedIn.Web.Models;
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
        ApplicationUser loginuser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        ApplicationDbContext db = new ApplicationDbContext();

        //public ApplicationUser loginuser
        //{
        //    get
        //    {
        //        return UnitOfWork.ApplicationUserManager.FindById(User.Identity.GetUserId());
        //    }
        //}

        // GET: NewsFeed
        [HttpGet]
        public ActionResult Index()
        {
            PostViewModel postVM = new PostViewModel
            {
                User = loginuser
            };
            return View(postVM);
        }
        
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            post.Author = loginuser;
            post.AuthorId = loginuser.Id;
            post.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PostViewModel postVM = new PostViewModel
            {
                User = loginuser
            };
            return View(postVM);
        }
    }
}