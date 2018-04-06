using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class CoursePlan
    {
        public List<Semester> Semesters { get; set; }   // this should allow us to accomodate more than 4 yr plans
    }

    public class ClientCoursePlan
    {
        public List<ClientCourseInfo> plan { get; set; }
    }

    public class ClientCourseInfo
    {
        public int semesterId { get; set; }
        public int courseId { get; set; }
    }

}