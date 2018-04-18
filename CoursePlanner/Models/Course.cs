using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class Course: IEquatable<Course>
    {
        public string Name { get; set; }
        public string DeptCode { get; set; }
        public int Id { get; set; }
        public int Credits { get; set; }
        public List<Course> Prerequisites { get; set; }
        public List<Course> Corequisites { get; set; }

        public bool Equals(Course other)
        {
            if (other.Id.Equals(Id)
                && other.DeptCode.Equals(DeptCode)
                && other.Credits.Equals(Credits)
                && other.Name.Equals(Name))
                return true;
            else
                return false;
        }
    }
}