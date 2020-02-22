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
            PostViewModel postVM = new PostViewModel();
            return View(postVM);
        }

        [HttpPost]
        public ActionResult AddPost(Post post, HttpPostedFileBase imgFile)
        {
            PostViewModel postVM = new PostViewModel();
            if (ModelState.IsValid && (post.Status != null || imgFile != null))
            {
                string pic = "";
                string path = "";
                if (imgFile != null)
                {
                    pic = System.IO.Path.GetFileName(imgFile.FileName);
                    path = System.IO.Path.Combine(Server.MapPath("~/SavedImages"), pic);
                    imgFile.SaveAs(path);
                    post.ImageUrl = path;
                }
                post.AuthorId = postVM.User.Id;
                post.Date = DateTime.Now;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", postVM);
        }
    }
}