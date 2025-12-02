using LBMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuedBookController : ControllerBase
    {
        private readonly IConfiguration _config;
        public IssuedBookController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("issue")]
        public IActionResult IssuBook(IssuedBook IB)
        {
            string query1 = "inert into students(Name,Email,Phone)values(@Name,@Email,@Phone)";
            string query2 = "inert into IssuedBooks(StudentId,BookId,IssuedId,Status)values(@StudentId,@BookId,@IssuedId,@Status)";
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("MyConnection")))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@Tittle", IB.StudentId);
                int rows = cmd1.ExecuteNonQuery();
                if (rows == 0)
                    return BadRequest("Student Not Found");
                cmd1.Parameters.AddWithValue("@Author", IB.BookId);
                SqlCommand cmd2 = new SqlCommand(query2, con);



            }
            return Ok("Student Added Successfully");
        }
    }
}
