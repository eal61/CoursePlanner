using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class DegreeProgram
    {
        public DegreeProgram(string newName, int newCreditRequirement, List<RequirementGroup> newRequirements, string newDepartment, string newSchool, string newCampus, Administrator newAdvisor)
        {
            var Name = newName;
            var CreditRequirement = newCreditRequirement;
            var Requirements = newRequirements;
            var Department = newDepartment;
            var School = newSchool;
            var Campus = newCampus;
            var Advisor = newAdvisor;

        }
        public string Name { get; set; }
        public int CreditRequirement { get; set; }
        public List<RequirementGroup> Requirements { get; set; }
        public string Department { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public Administrator Advisor { get; set; }
    }
}