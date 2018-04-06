using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CoursePlanner.Models;
using System.Web.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;

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
        public IHttpActionResult Post()
        {
            return Ok();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-CoursePlanner-20180131110323.mdf;Initial Catalog=aspnet-CoursePlanner-20180131110323;Integrated Security=True";
            int success;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("", conn);
                command.Parameters.Add(new SqlParameter());
                command.Parameters.Add(new SqlParameter());
                success = command.ExecuteNonQuery();
                conn.Close();
            }
            return Ok(success > 0);
        }
    }
}
