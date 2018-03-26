using System;
using System.Collections.Generic;
using CoursePlanner.Models;
using System.Data.SqlClient;

namespace CoursePlanner.Controllers
{
    public class StudentController
    {

        /// <summary>
        /// Use to get conglomerate list of all student degree programs - majors and minors
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<DegreeProgram> getAllDegreePrograms(int studentId) {
            // use student Id to get student
            List<DegreeProgram> degreePrograms= new List<DegreeProgram>();
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM student_degree WHERE student_id = 0", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));


                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        degreePrograms.add(reader["degree_id"]); 
                    }
                }
            }
            return degreePrograms;
        }

    }
}