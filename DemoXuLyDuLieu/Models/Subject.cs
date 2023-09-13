using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoXuLyDuLieu.Models
{
    public class Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }

        public Subject(string subjectID, string subjectName)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
        }
    }
}