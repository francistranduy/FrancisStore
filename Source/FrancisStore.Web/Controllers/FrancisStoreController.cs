using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public abstract class FrancisStoreController : Controller
    {
        #region LayoutPartialView
        [ChildActionOnly]
        public ActionResult HeaderFixed()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult TopNotification()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
        #endregion
    }
}