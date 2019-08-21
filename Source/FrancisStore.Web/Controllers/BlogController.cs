using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        #region PartialView

        [ChildActionOnly]
        public ActionResult BreadCrumb()
        {
            return PartialView("_BreadCrumb");
        }

        [ChildActionOnly]
        public ActionResult Search()
        {
            return PartialView("_Search");
        }

        [ChildActionOnly]
        public ActionResult Categories()
        {
            return PartialView("_Categories");
        }

        [ChildActionOnly]
        public ActionResult FeaturedProduct()
        {
            return PartialView("_FeaturedProduct");
        }

        [ChildActionOnly]
        public ActionResult Archive()
        {
            return PartialView("_Archive");
        }

        [ChildActionOnly]
        public ActionResult Tags()
        {
            return PartialView("_Tags");
        }

        #endregion
    }
}