using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class Course
    {
        public string DeptCode { get; set; }
        public int CourseNumber { get; set; }
        public List<Course> Prerequisites { get; set; }
        public List<Course> Corequisites { get; set; }
        public bool AdvancedElective { get; set; }      // unsure if this is enough to scale up
        public bool TechnicalElective { get; set; }
        public bool OpenElective { get; set; }

    }
}