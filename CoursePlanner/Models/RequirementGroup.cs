using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class RequirementGroup
    {
        public string GroupName { get; set; }           // i.e. core, freshman, 
        public int TotalCredits { get; set; }           // how many credits needed to satisfy req
        public List<Course> MandatoryCourses { get; set; }     // any courses that MUST be taken to satisfy this req
        public List<Course> FulfillmentCourses { get; set; }  //any courses that are not mandatory but count towards the requirement group
    }
}