using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinhThiTuyetChinh_Exercise1.Models;

namespace DinhThiTuyetChinh_Exercise1.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHoc
        public ActionResult Index()
        {
            Database1Entities1 db = new Database1Entities1();
            // Lấy tất cả thông ti từ DB
           List<MONHOC> mh = db.MONHOCs.ToList();
            return View(mh);
        }
    }
}