using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class Course
    {
        public string Name { get; set; }
        public string DeptCode { get; set; }
        public int Id { get; set; }
        public List<Course> Prerequisites { get; set; }
        public List<Course> Corequisites { get; set; }

    }
}