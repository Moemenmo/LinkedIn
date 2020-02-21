using Linkedin.Models.Entites;
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
    }
}