using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class HomeController : FrancisStoreController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region HomePagePartialView

        [ChildActionOnly]
        public ActionResult Slide()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult OurProduct()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult BannerVideo()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Blog()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Instagram()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Shipping()
        {
            return PartialView();
        }

        #endregion
    }
}