using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinhThiTuyetChinh_Exercise3.Models;
using DinhThiTuyetChinh_Exercise3.Services;
namespace DinhThiTuyetChinh_Exercise3.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        public ActionResult showKhoa()
        {
            try
            {
                List<KhoaModel> khoaModels = KhoaService.excuteSQL();
                return View(khoaModels);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
    }
}