using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThiTuyetChinh_Exercise4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult GetEmployeeName(int employeeID)
        {
            var employee = new[]
            {
                new { emplID = 1, emplName = "Văn", salary = 2000 },
                new { emplID = 2, emplName = "An", salary = 9000 },
                new { emplID = 3, emplName = "Ngọc", salary = 7000 }
            };
            string matchEmpName = null;
            foreach(var item in employee)
            {
                if(item.emplID == employeeID)
                {
                    matchEmpName = item.emplName;
                }    
            } 
            //return new ContentResult() { Content = matchEmpName, ContentType = "text/ plain" };
            //Cách 2
            return Content(matchEmpName, "text/ plain");

        }
        public ActionResult getSalary(int emplID)
        {
            string fileName = "~/bang-luong-" + emplID + ".pdf";
            return File(fileName, "application/pdf");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}