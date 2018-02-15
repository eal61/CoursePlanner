using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoursePlanner.Models;

namespace CoursePlanner.Controllers
{
    public class StudentController
    {
        /// <summary>
        /// Use to get conglomerate list of all student degree programs - majors and minors
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<DegreeProgram> getAllDegreePrograms(/*TODO implement this: int studentId*/) {
            // use student Id to get student
            Student student = new Student();

            student.Majors = new List<DegreeProgram>();
            student.Minors = new List<DegreeProgram>();
            student.Majors.Add(new DegreeProgram {
                Name = "Computer Engineering",
                CreditRequirement = 125,
                School = "Pitt Campus"
            });
            student.Majors.Add(new DegreeProgram
            {
                Name = "Mechanical Engineering",
                CreditRequirement = 125,
                School = "Pitt Campus"
            });

            student.Minors.Add(new DegreeProgram
            {
                Name = "Economics",
                CreditRequirement = 15,
                School = "Pitt Campus"
            });

            List<DegreeProgram> programs = new List<DegreeProgram>();

            student.Majors.ForEach(major => {
                programs.Add(major);
            });
            student.Minors.ForEach(minor => {
                programs.Add(minor);
            });

            return programs;
        }

    }
}