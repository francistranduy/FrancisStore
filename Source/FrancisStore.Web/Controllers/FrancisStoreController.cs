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
            return PartialView("_HeaderFixed");
        }

        [ChildActionOnly]
        public ActionResult TopNotification()
        {
            return PartialView("_TopNotification");
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("_Header");
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }
        #endregion
    }
}