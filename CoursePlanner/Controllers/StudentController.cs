using System;
using System.Collections.Generic;
using CoursePlanner.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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
            List<DegreeProgram> degreePrograms= new List<DegreeProgram>();

            // using (SqlConnection conn = new SqlConnection())
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "Server=localhost; Database = test_db; User Id = srdesign; Password=1234@Password";

                MySqlCommand command = new MySqlCommand("SELECT * FROM student_degree WHERE student_id = 0", conn);
                command.Parameters.Add(new MySqlParameter("0", studentId));


                using(MySqlDataReader reader = command.ExecuteReader())
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