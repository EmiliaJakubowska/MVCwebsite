using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwebsite.Models;

namespace MVCwebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(User user)
        {
            using (UserRegistrationDBEntities db = new UserRegistrationDBEntities())
            {
                var userDetail = db.Users.Single(x => x.UserName == user.UserName && x.Password == user.Password);
                if (userDetail == null)
                {
                    ViewBag.DuplicateMessage = "Niepoprawny login lub hasło.";
                    return View("Login", user);
                }
                else
                {
                    Session["userID"] = user.UserID;
                    Session["userName"] = user.UserName;
                    return RedirectToAction("Logged", "Logged");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}