using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class AboutController : FrancisStoreController
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}