using LBMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AddStudentController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("add")]
        public IActionResult AddStudent(Student s)
        {
            string query = "inert into students(Name,Email,Phone)values(@Name,@Email,@Phone)";
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("MyConnection")))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Tittle", s.Name);
                cmd.Parameters.AddWithValue("@Author", s.Email);
                cmd.Parameters.AddWithValue("@Quantity", s.Phone);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return Ok("Student Added Successfully");
        }
    }
}
