using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinhThiTuyetChinh_Exercise1.Models;
namespace DinhThiTuyetChinh_Exercise1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult showMonHoc()
        {
           List<Student> studentList = new List<Student>();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    string conStr = "Data Source = TUYETCHINH\\SQLSERVER1; Initial Catalog = QLSV; Integrated Security = true";
                    connection.ConnectionString = conStr;
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string selectStr = "SELECT * FROM MONHOC";
                    SqlCommand cmd = new SqlCommand(selectStr, connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string mhId = rdr["MAMH"].ToString();
                        string mhName = rdr["TENMH"].ToString();
                        Student student = new Student(mhId, mhName);
                        studentList.Add(student);
                    }    
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }  
                    
                }   
                return View(studentList);
            } catch(Exception ex)
            {
                // return RedirectToAction("Error");
                return Content(ex.Message);
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}