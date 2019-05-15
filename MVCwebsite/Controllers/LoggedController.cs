using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwebsite.Controllers
{
    public class LoggedController : Controller
    {
        // GET: Logged
        public ActionResult Logged()
        {
            return View();
        }
    }
}