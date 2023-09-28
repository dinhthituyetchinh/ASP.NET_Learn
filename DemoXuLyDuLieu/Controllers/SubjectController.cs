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
                List<Subject> filterSubject = TempData["filterSubject"] as List<Subject>;
                if (filterSubject != null && filterSubject.Count > 0 )
                {
                    return View(filterSubject);
                }  
                
               List<Subject> s =  SubjectService.ExcuteSQL();
                return View(s);
            } catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult findSubject(string name)
        {
            try
            {
                List<Subject> s = SubjectService.ExcuteSQL();
                List<Subject> filterSubject = s.Where(subject => subject.SubjectName.Contains(name)).ToList();
                TempData["filterSubject"] = filterSubject;
                return RedirectToAction("showSubjects");
            }
            catch (Exception ex)
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
                if (id == "")
                {
                    ViewData["err"] = "e1";
                    return View("addSubject");
                }
                if (id.Length > 10)
                {
                    ViewData["err1"] = "e2";
                    return View("addSubject");
                }
                if (SubjectService.checkPrimary(id) == false)
                {
                    ViewData["err2"] = "e3";
                    return View("addSubject");
                }
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