using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Controllers
{
    public class ContactController : FrancisStoreController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}