using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private SchoolDBEntities db = new SchoolDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblUser user)
        {
            if (ModelState.IsValid)
            {
                var check = db.tblUsers.FirstOrDefault(s => s.Username == user.Username && s.Password == user.Password);
                if (check == null)
                {
                    ViewBag.ErrorMessage = "Incorrect username or password!";
                    return View();
                }
                else
                {
                    Session["UserID"] = check.UserID;
                    Session["Username"] = check.Username;
                    return RedirectToAction("Index", "Students");
                }
            }
            return View();
        }
    }
}