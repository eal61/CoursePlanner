using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CoursePlanner.Models;
using System.Web.Http;
using System.Net.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using App.Extensions;

namespace CoursePlanner.Controllers
{
    public class CoursePlanController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var name = User.Identity.Name;
            return Ok(name);
        }

        [HttpPost]
        public IHttpActionResult Post(List<Object> plan)
        {
            ClientCoursePlan planList = new ClientCoursePlan();
            planList.plan = new List<ClientCourseInfo>(); 
            plan.ForEach(p => {
                ClientCourseInfo info = JsonConvert.DeserializeObject<ClientCourseInfo>(p.ToString());
                planList.plan.Add(info);
            });

            int studentId = planList.plan[0].studentId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            int success;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // remove old classes
                SqlCommand deleteCommand = new SqlCommand("DELETE from student_course WHERE student_id=@0", conn);
                deleteCommand.Parameters.Add(new SqlParameter("0", studentId));
                deleteCommand.ExecuteNonQuery();

                // add new configuration
                planList.plan.ForEach(p => {
                    SqlCommand command = new SqlCommand("INSERT into student_course (course_id, student_id, semester_id) values (@0, @1, @2)", conn);
                    command.Parameters.Add(new SqlParameter("0", p.courseId));
                    command.Parameters.Add(new SqlParameter("1", p.studentId));
                    command.Parameters.Add(new SqlParameter("2", p.semesterId));
                    success = command.ExecuteNonQuery();
                });
                conn.Close();
            }
            return Ok();
        }
    }
}
