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

        #region HomePagePartialView

        [ChildActionOnly]
        public ActionResult Slide()
        {
            return PartialView("_Slide");
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            return PartialView("_Banner");
        }

        [ChildActionOnly]
        public ActionResult OurProduct()
        {
            return PartialView("_OurProduct");
        }

        [ChildActionOnly]
        public ActionResult BannerVideo()
        {
            return PartialView("_BannerVideo");
        }

        [ChildActionOnly]
        public ActionResult Blog()
        {
            return PartialView("_Blog");
        }

        [ChildActionOnly]
        public ActionResult Instagram()
        {
            return PartialView("_Instagram");
        }

        [ChildActionOnly]
        public ActionResult Shipping()
        {
            return PartialView("_Shipping");
        }
        #endregion
    }
}