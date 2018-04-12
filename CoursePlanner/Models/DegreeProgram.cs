using CoursePlanner.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CoursePlanner.Models
{
    public class DegreeProgram
    {
        public DegreeProgram(string newName, string newDept, bool major, bool minor)
        {
            Name = newName;
            Department = newDept;
            Major = false;
            Minor = false;
            Other = false;

            if (major)
            {
                Major = true;
            }
            else if (minor)
            {
                Minor = true;

            }
            else
            {
                Other = true;
            }


        }
        public string Name { get; set; }
        public int CreditRequirement { get; set; }
        public List<RequirementGroup> Requirements { get; set; }
        public string Department { get; set; }
        public bool Major { get; set; }
        public bool Minor { get; set; }
        public bool Other { get; set; }


    }
}