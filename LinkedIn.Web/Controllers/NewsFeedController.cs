using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    public class NewsFeedController : Controller
    {
        // GET: NewsFeed
        public ActionResult Index()
        {
            return View();
        }
    }
}