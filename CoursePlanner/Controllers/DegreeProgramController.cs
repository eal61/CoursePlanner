using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoursePlanner.Models;
using System.Data.SqlClient;

namespace CoursePlanner.Controllers
{
    /// <summary>
    /// Use this class to get information about a degree program
    /// </summary>
    public class DegreeProgramController
    {
        public void fillDegreeRequirements(DegreeProgram degree, int degreeID)
        {
            List<RequirementGroup> reqGroupList = new List<RequirementGroup>();

            int REQUIREMENTCLASSES = 6; //4/6/18 there are 6 requirement classes in database

            int[] creditReq = new int[REQUIREMENTCLASSES]; //keep track of each requirement classes credit requirement

            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True;MultipleActiveResultSets = True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //get all courses that are within the specific degree program
                SqlCommand command = new SqlCommand("SELECT * FROM course_degree cd JOIN degree d on cd.degree_id=d.degree_id WHERE d.degree_id = @0", conn);



                command.Parameters.Add(new SqlParameter("0", degreeID));


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //create the array to hold each requirements class's list of countable classes
                    List<Course>[] reqCourses = new List<Course>[REQUIREMENTCLASSES];
                    List<Course>[] countCourses = new List<Course>[REQUIREMENTCLASSES];



                    for (int i = 0; i < REQUIREMENTCLASSES; i++)
                    {
                        reqCourses[i] = new List<Course>();
                        countCourses[i] = new List<Course>();
                    }

                    Course course;
                    while (reader.Read())
                    {

                        int courseId = (int)reader["course_id"];
                        int reqNo = (int)reader["requirement_id"];
                        //get the course from the course table  
                        SqlCommand command2 = new SqlCommand("SELECT * FROM course c JOIN course_degree dc on dc.course_id=c.course_id WHERE c.course_id = @0 AND dc.degree_id=@1", conn);



                        command2.Parameters.Add(new SqlParameter("0", courseId));
                        command2.Parameters.Add(new SqlParameter("1", degreeID));


                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            //collect info about each course (most importantly the credits)
                            while (reader2.Read())
                            {
                                course = new Course();
                                course.Name = (String)reader2["course_name"];
                                course.Id = (int)reader2["course_id"];
                                course.Credits = (int)reader2["credits"];
                                course.DeptCode = (String)reader2["DEPT_No"];

                               

                                if ((bool)reader2["mandatory"])
                                {
                                    reqCourses[reqNo].Add(course);
                                }
                                else
                                {
                                    countCourses[reqNo].Add(course);
                                }
                                
                                if (reqNo == 0 || reqNo == 3)
                                {
                                    creditReq[reqNo] = creditReq[reqNo] + course.Credits;
                                }
                            }


                        }


                    }

                    command = new SqlCommand("SELECT * FROM degree d WHERE degree_id = @0", conn);
                    command.Parameters.Add(new SqlParameter("0", degreeID));

                    using (SqlDataReader reader3 = command.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            creditReq[1] = 3 * (int)reader3["advCoreElectiveNum"];
                            creditReq[2] = 3 * (int)reader3["openElectiveNum"];
                            creditReq[4] = 3 * (int)reader3["techElectiveNum"];
                            creditReq[5] = 3 * (int)reader3["hssElectiveNum"];
                        }
                    }

                    for (int j = 0; j < REQUIREMENTCLASSES; j++)
                    {
                        RequirementGroup rg = new RequirementGroup();
                        rg.MandatoryCourses = reqCourses[j];
                        rg.FulfillmentCourses = countCourses[j];
                        rg.TotalCredits = creditReq[j];
                        switch (j)
                        {
                            case 0:
                                rg.GroupName = "Core Classes";
                                break;
                            case 1:
                                rg.GroupName = "Advanced Electives";
                                break;
                            case 2:
                                rg.GroupName = "Open Electives";
                                break;
                            case 3:
                                rg.GroupName = "Freshman Requirement";
                                break;
                            case 4:
                                rg.GroupName = "Technical Elective";
                                break;
                            case 5:
                                rg.GroupName = "Humanities/Social Sciences Elective";
                                break;
                        }


                        reqGroupList.Add(rg);

                    }
                    conn.Close();

                }
                degree.Requirements = reqGroupList;
                int degreeCredits = 0;
                for (int n = 0; n < REQUIREMENTCLASSES; n++)
                {
                    degreeCredits = degreeCredits + creditReq[n];
                }
                degree.CreditRequirement = degreeCredits;

            }
        }
    }
}