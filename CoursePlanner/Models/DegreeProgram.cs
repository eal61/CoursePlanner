using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class DegreeProgram
    {
        public string Name { get; set; }
        public int CreditRequirement { get; set; }
        public List<RequirementGroup> Requirements { get; set; }
        public string Department { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public Administrator Advisor { get; set; }
    }
}