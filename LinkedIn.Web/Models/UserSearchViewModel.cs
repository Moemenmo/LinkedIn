using Linkedin.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class UseSearchViewModel
    {
        public ApplicationUser User { get; set; }
        public UserType UserType { get; set; }
    }
}