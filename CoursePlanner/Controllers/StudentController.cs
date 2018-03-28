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
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM student_degree WHERE student_id = @0", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));


                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        Console.WriteLine(reader["degree_id"]);
                    }
                }
                conn.Close();
            }


            return degreePrograms;
        }
        public List<CoursePlan> getCoursePlan(int studentId) {
            // use student Id to get student
            List<DegreeProgram> degreePrograms= new List<DegreeProgram>();
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM student_course WHERE student_id = @0", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));


                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        Console.WriteLine(reader["degree_id"]);
                    }
                }
                conn.Close();

            }
            return degreePrograms;
        }
        public void addCourse(int studentId, Course c)
        {
            // use student Id to get student
            List<DegreeProgram> degreePrograms = new List<DegreeProgram>();
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT into student_course (course_id, student_id, semester_id) values (@0, @1, @2)", con);
                command.Parameters.Add(new SqlParameter("0", studentId));
                command.Parameters.Add(new SqlParameter("1", courseId));
                command.Parameters.Add(new SqlParameter("2", semestersId));
                conn.Close();

            }
            return degreePrograms;
        }
        public void addDegreeProgram(int studentId, int degreeId)
        {
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT into student_degree (student_id, degree_id) values (@0, @1)", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));
                command.Parameters.Add(new SqlParameter("1", degreeId));


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        Console.WriteLine(reader["degree_id"]);
                    }
                }
                conn.Close();

            }
        }
        /*public void updateDegreeProgram(DegreeProgram degree)
        {
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("", conn);
                command.Parameters.Add(new SqlParameter());

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        Console.WriteLine(reader["degree_id"]);
                    }
                }
                conn.Close();

            }
        }*/

    }
}