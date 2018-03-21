using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoursePlanner.Models;

namespace CoursePlanner.Controllers
{
    public class StudentController
    {
//   <connectionStrings>
//     <add name="DefaultConnection" 
//     connectionString="Data Source=(LocalDb)\MSSQLLocalDB;
//     AttachDbFilename=|DataDirectory|\aspnet-CoursePlanner-20180131110323.mdf;
//     Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True" 
//     providerName="System.Data.SqlClient" />

        /// <summary>
        /// Use to get conglomerate list of all student degree programs - majors and minors
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<DegreeProgram> getAllDegreePrograms(int studentId) {
            // use student Id to get student
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = 
                "Server=MSSQLLocalDB;
                Database=aspnet-CoursePlanner-20180131110323.mdf;
                Trusted_Connection=true";


                
                SqlCommand command = new SqlCommand("SELECT * FROM StudentDegree WHERE FirstColumn = @0", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t",
                            reader[0], reader[1]));
                    }
                }
            }
            
            Student student = new Student();

            student.Majors = new List<DegreeProgram>();
            student.Minors = new List<DegreeProgram>();
            student.Majors.Add(new DegreeProgram {
                Name = "Computer Engineering",
                CreditRequirement = 125,
                School = "Pitt Campus",
                Requirements = new List<RequirementGroup>()
            });
            student.Majors.Add(new DegreeProgram
            {
                Name = "Mechanical Engineering",
                CreditRequirement = 125,
                School = "Pitt Campus",
                Requirements = new List<RequirementGroup>()
            });

            student.Minors.Add(new DegreeProgram
            {
                Name = "Economics",
                CreditRequirement = 15,
                School = "Pitt Campus",
                Requirements = new List<RequirementGroup>()
            });

            student.Majors[0].Requirements.Add(new RequirementGroup {
                GroupName = "Group 1",
                MandatoryCourses = new List<Course>()
            });

            student.Majors[0].Requirements[0].MandatoryCourses.Add(new Course {
                Name = "Course 1",
                Id = 1
            });

            student.Majors[0].Requirements[0].MandatoryCourses.Add(new Course
            {
                Name = "Course 2",
                Id = 2
            });

            student.Majors[0].Requirements.Add(new RequirementGroup
            {
                GroupName = "Group 2",
                MandatoryCourses = new List<Course>()
            });

            student.Majors[0].Requirements[1].MandatoryCourses.Add(new Course
            {
                Name = "Course 1",
                Id = 1
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