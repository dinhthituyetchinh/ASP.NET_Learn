using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoXuLyDuLieu.Models;
using DemoXuLyDuLieu.Services;
namespace DemoXuLyDuLieu.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult showSubjects()
        {
            try
            {
               List<Subject> s =  SubjectService.ExcuteSQL();
                return View(s);
            } catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult addSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addSubject(string id, string name)
        {
            try
            {
                 SubjectService.addSql(id, name);
                return RedirectToAction("showSubjects");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }


        public ActionResult deleteSubject(string id)
        {
            try
            {
                SubjectService.deleteSql(id);
                return RedirectToAction("showSubjects");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult updateSubject(string id)
        {
            try
            {
               Subject s =  SubjectService.find(id);
                Session["id"] = s.SubjectID;
                return View(s);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult updateSubjects(string name)
        {
            try
            {
                SubjectService.updateSql(Session["id"].ToString(), name);              
                return RedirectToAction("showSubjects");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}