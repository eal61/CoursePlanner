using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class Semester
    {
        public string Code { get; set; }
        public List<Course> Courses { get; set; }
        public bool Complete { get; set; }
        public int TotalCredits { get; set; }
    }
}