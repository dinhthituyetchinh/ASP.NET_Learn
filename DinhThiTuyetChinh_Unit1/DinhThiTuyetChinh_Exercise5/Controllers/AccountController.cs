using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThiTuyetChinh_Exercise5.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn(string username, string password)
        {
           if(username == "van" && password == "123456")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return RedirectToAction("InvalidLogIn");
            }
        }
        public ActionResult InvalidLogIn()
        {
            return View();
        }
    }
}