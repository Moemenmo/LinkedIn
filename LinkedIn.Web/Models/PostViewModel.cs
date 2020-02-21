using Linkedin.Models.Entites;
using LinkedIn.Core.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public ApplicationUser User { get; set; }
        public PostViewModel()
        {
            User= HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }
    }
}