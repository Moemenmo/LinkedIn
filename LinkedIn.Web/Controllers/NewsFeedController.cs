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
            List<Post> darft = new List<Post>();
            var userManager = UnitOfWork.ApplicationUserManager;
            PostViewModel postVM = new PostViewModel();
            if (postVM.User.Posts!=null)
            {

            darft.AddRange(postVM.User.Posts);
            }

            foreach (var item in userManager.GetAllConnections(User.Identity.GetUserId().ToString()))
            {
                darft.AddRange(item.Posts);
            }
            //postVM.PagePosts.OrderBy(e => e.Date.Year)
            //    .ThenBy(e => e.Date.Month)
            //    .ThenBy(e => e.Date.Day)
            //    .ThenBy(e => e.Date.TimeOfDay.Hours)
            //    .ThenBy(e => e.Date.TimeOfDay.Minutes)
            //    .ThenBy(e => e.Date.TimeOfDay.Seconds);
            postVM.PagePosts=darft.OrderByDescending(d => Convert.ToDateTime(d.Date)).ToList();
            return View(postVM);
        }

        [HttpPost]
        public ActionResult AddPost(Post post, HttpPostedFileBase imgFile)
        {
            var userManager = UnitOfWork.ApplicationUserManager;
            var postManager = UnitOfWork.PostManager;

            //PostViewModel postVM = new PostViewModel();
            if (ModelState.IsValid && (post.Status != null || imgFile != null))
            {
                string pic = "";
                string path = "";
                if (imgFile != null)
                {
                    pic = System.IO.Path.GetFileName(imgFile.FileName+post.Id);
                    path = System.IO.Path.Combine(Server.MapPath("~/SavedImages"), pic);
                    imgFile.SaveAs(path);
                    post.ImageUrl = path;
                }
                post.AuthorId = User.Identity.GetUserId();
                post.Date = DateTime.Now;
                postManager.Add(post);
                post.Author = userManager.FindById(User.Identity.GetUserId());
                return PartialView("_PostBody",post);
            }
            return View("Index"
                //, postVM
                );
        }
    }
}