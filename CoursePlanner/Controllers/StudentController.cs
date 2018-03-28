using System;
using System.Collections.Generic;
using CoursePlanner.Models;
using System.Data.SqlClient;


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
            Student student1 = new Student();
            student1.Plan = cp;


            // fake data
            var student = new Student();
            student.Plan = new CoursePlan();
            student.Plan.Semesters = new List<Semester>();
            student.Plan.Semesters.Add(new Semester { Code = 1, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 2, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 3, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 4, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 5, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 6, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 7, Complete = false, Courses = new List<Course>() });
            student.Plan.Semesters.Add(new Semester { Code = 8, Complete = false, Courses = new List<Course>() });

            student.Plan.Semesters[0].Courses.Add(new Course { Id = 1, Name = "Course 1" });
            student.Plan.Semesters[0].Courses.Add(new Course { Id = 2, Name = "Course 2" });
            student.Plan.Semesters[0].Courses.Add(new Course { Id = 3, Name = "Course 3" });
            student.Plan.Semesters[0].Courses.Add(new Course { Id = 4, Name = "Course 4" });

            return student;
        }

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

                //TODO need to join with degree table
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()){
                        Console.WriteLine(reader["degree_id"]);
                        //DegreeProgram dp = new DegreeProgram(string reader[""], etc.); //TODO get all inputs for new DegreeProgram
                        
                    }
                }
                conn.Close();
            }


            return degreePrograms;
        }
        public CoursePlan getCoursePlan(int studentId) {
            // use student Id to get student
            CoursePlan cp = new CoursePlan();
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM student_course WHERE student_id = @0", conn);
                  //TODO JOIN with course table
                command.Parameters.Add(new SqlParameter("0", studentId));


                using(SqlDataReader reader = command.ExecuteReader())
                {
                    List<Course>[] courseList = new List<Course>[8];
                    for(int i=0; i<8;i++)
                    {
                        courseList[i] = new List<Course>();
                    }
                    Course course;
                    while (reader.Read()){
                        course = new Course();
                        course.Name = (String)reader["course_name"];
                        course.Id = (int)reader["course_id"];
                        course.DeptCode = (String)reader["course_number"];


                        courseList[(int)reader["semester-id"]-1].Add(course);
                    }
                    List<Semester> sems = new List<Semester>();
                    for(int i=0;i<8;i++)
                    {
                        Semester currSem = new Semester();
                        currSem.Courses = courseList[i];
                        currSem.Code = i+1;
                        sems.Add(currSem);
                    }
                    cp.Semesters = sems;
                }
                conn.Close();

            }
            return cp;
        }


        public void addCourse(int studentId, int courseId, int semesterId)
        {
            // use student Id to get student
            //string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT into student_course (course_id, student_id, semester_id) values (@0, @1, @2)", conn);
                command.Parameters.Add(new SqlParameter("0", studentId));
                command.Parameters.Add(new SqlParameter("1", courseId));
                command.Parameters.Add(new SqlParameter("2", semesterId));
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