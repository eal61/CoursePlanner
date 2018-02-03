using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public interface PersonModels
    {
        string FirstName { get; set; }
        string LastName { get; set; }

    }

    public class Student : PersonModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<DegreeProgram> Majors { get; set; }
        public List<DegreeProgram> Minors { get; set; }
        public CoursePlan Plan { get; set; }
    }

    public class Administrator {

    }
}