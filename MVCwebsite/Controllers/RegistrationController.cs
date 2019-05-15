using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwebsite.Models;

namespace MVCwebsite.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration(int id = 0)
        {
            User user = new User();
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            using (UserRegistrationDBEntities db = new UserRegistrationDBEntities())
            {
                if (db.Users.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "Użytkownik już istnieje.";
                    return View("Registration", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Rejestracja udana.";
            return View("Registration", new User());
        }
    }
}