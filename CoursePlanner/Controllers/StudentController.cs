﻿using System;
using System.Collections.Generic;
using CoursePlanner.Models;
using System.Data.SqlClient;
using App.Extensions;
using Microsoft.AspNet.Identity;

namespace CoursePlanner.Controllers
{
    public class StudentController
    {   
        public Student getStudentInfo(int studentId)
        {
            // call db to retrieve student data
            //StudentController studentController = new StudentController();
            // set up list for radio buttons to select progress bar to view
            CoursePlan cp = this.getCoursePlan(studentId); // TODO need to set up student id
            Student student = new Student();
            student.Plan = cp;
            //student.FirstName = HttpContext.User.Identity.GetFirstName();
           // student.LastName = HttpContext.User.Identity.GetLastName();
            return student;

           
        }

        /// <summary>
        /// Use to get conglomerate list of all student degree programs - majors and minors
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>

        public List<DegreeProgram> getAllDegreePrograms(int studentId) {
            // use student Id to get student
           
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            List<DegreeProgram> degrees = new List<DegreeProgram>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                


               

                SqlCommand command = new SqlCommand("SELECT * FROM student_degree JOIN degree on student_degree.degree_id=degree.degree_id WHERE student_id = @0", conn);

                //SqlCommand command = new SqlCommand( "SELECT * FROM student_degree WHERE student_id = @0", conn);

                command.Parameters.Add(new SqlParameter("0", studentId));
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) {

                        //DegreeProgram dp = new DegreeProgram();
                        //string reader["degree"], etc.); //TODO get all inputs for new DegreeProgram
                        //degrees.Add(dp);
                    }
                }
                conn.Close();
            }


            return degrees;
        }
        public CoursePlan getCoursePlan(int studentId) {
            // use student Id to get student
            CoursePlan cp = new CoursePlan();
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM student_course sc JOIN course c on sc.course_id=c.course_id WHERE student_id = @0", conn);
             

                
                command.Parameters.Add(new SqlParameter("0", studentId));


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Course>[] courseList = new List<Course>[8];
                    for (int i = 0; i < 8; i++)
                    {
                        courseList[i] = new List<Course>();
                    }
                    Course course;
                    while (reader.Read()) {
                        course = new Course();
                        course.Name = (String)reader["course_name"];
                        course.Id = (int)reader["course_id"];
                        course.DeptCode = (String)reader["DEPT_No"];


                        courseList[(int)reader["semester_id"]].Add(course);
                    }
                    List<Semester> sems = new List<Semester>();
                    for (int i = 0; i < 8; i++)
                    {
                        Semester currSem = new Semester();
                        currSem.Courses = courseList[i];
                        currSem.Code = i + 1;
                        sems.Add(currSem);
                    }
                    cp.Semesters = sems;
                }
                conn.Close();

            }
            return cp;
        }
        public int getClass(String name)
        {
            int course_id = -1;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM course WHERE DEPT_NO = @0", conn);
                

                
                command.Parameters.Add(new SqlParameter("0", (String)name));
                using (SqlDataReader reader = command.ExecuteReader())
                { 
                if (reader.Read())
                    course_id = (int)reader["course_id"];
                }
                return course_id;

            }
        }
            public int addCourse(int studentId, String course_name, int semesterId)
        {
            int course_id = getClass(course_name);
            if (course_id == -1)
            {
                return -1;
            }
            else
            {
                string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT into student_course (course_id, student_id, semester_id) values (@0, @1, @2)", conn);
                    command.Parameters.Add(new SqlParameter("0", course_id));
                    command.Parameters.Add(new SqlParameter("1", studentId));
                    command.Parameters.Add(new SqlParameter("2", semesterId));
                    command.ExecuteNonQuery();
                    conn.Close();

                }
            }
            return 0;
        }

        public void removeCourse(int studentId, String course_name, int semesterId)
        {
            Console.WriteLine("class: " + course_name);
            int course_id = getClass(course_name);
            Console.WriteLine("id: " + course_id);
            // use student Id to get student
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("DELETE from student_course WHERE (course_id = @0 AND student_id=@1 AND semester_id = @2)", conn);
                command.Parameters.Add(new SqlParameter("0", course_id));
                command.Parameters.Add(new SqlParameter("1", studentId));
                command.Parameters.Add(new SqlParameter("2", semesterId));
                command.ExecuteNonQuery();
                conn.Close();

            }
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