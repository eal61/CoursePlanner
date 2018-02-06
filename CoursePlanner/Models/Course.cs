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

    }
}