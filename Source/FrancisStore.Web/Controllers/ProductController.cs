using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class ProductController : FrancisStoreController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        #region ProductPartialView
        [ChildActionOnly]
        public ActionResult Categories()
        {
            return PartialView("_Categories");
        }

        [ChildActionOnly]
        public ActionResult Filters()
        {
            return PartialView("_Filters");
        }

        [ChildActionOnly]
        public ActionResult Sorting()
        {
            return PartialView("_Sorting");
        }

        [ChildActionOnly]
        public ActionResult Products()
        {
            return PartialView("_Products");
        }

        [ChildActionOnly]
        public ActionResult Pagination()
        {
            return PartialView("_Pagination");
        }
        #endregion
    }
}