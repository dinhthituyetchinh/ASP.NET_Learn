using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DinhThiTuyetChinh_Exercise1.Models;
namespace DinhThiTuyetChinh_Exercise1.Models
{
    public class Student
    {
        public string MonHocId { get; set; }
        public string MonHocName { get; set; }
        public Student(string monHocId, string monHocName)
        {
            MonHocId = monHocId;
            MonHocName = monHocName;
        }
    }
}