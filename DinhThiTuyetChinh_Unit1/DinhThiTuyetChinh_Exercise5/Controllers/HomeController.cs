using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThiTuyetChinh_Exercise5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult EmplFbPage(int empl)
        {
            var employees = new[]
                {
                new {EmplID = 1, EmplName = "Văn", Salary = 5000},
                new {EmplID = 2, EmplName = "Anh", Salary = 3000},
                new {EmplID = 3, EmplName = "Nam", Salary = 6000},
            };
            string fbUrl = null;
            foreach(var emp in employees)
            {
              if(emp.EmplID == empl)
                {
                    fbUrl = "https://www.facebook.com/fengdinh";
                }    
            }  
            if(fbUrl == null)
            {
                return Content("Không tồn tại");
            } 
            return Redirect(fbUrl);
        }
    }
}