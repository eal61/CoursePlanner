using CoursePlanner.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CoursePlanner.Models
{
    public class DegreeProgram
    {
        public DegreeProgram(string newName, string newDept)
        {
            var Name = newName;
            var Department = newDept;
            DegreeProgramController dpControl = new DegreeProgramController();
            dpControl.fillDegreeRequirements(this, 0); //TODO add in get studentID function here and replace into 0

           
             
        }
        public string Name { get; set; }
        public int CreditRequirement { get; set; }
        public List<RequirementGroup> Requirements { get; set; }
        public string Department { get; set; }

 
    }
}