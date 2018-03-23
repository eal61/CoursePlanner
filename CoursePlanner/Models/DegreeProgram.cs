using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePlanner.Models
{
    public class DegreeProgram
    {
        public DegreeProgram(string newName, int newCreditRequirement, List<RequirementGroup> newRequirements, \
        string newDepartment, string newSchool, string newCampus, Administrator newAdvisor)
        {
            Name = newName;
            CreditRequirement = newCreditRequirement;
            Requirements = newRequirements;
            Department = newDepartment;
            School = newSchool;
            Campus = newCampus;
            Advisor = newAdvisor;

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