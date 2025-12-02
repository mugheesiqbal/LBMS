using LBMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AddBookController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("add")]
        public IActionResult AddBook(Books b)
        {
            string query = "inert into books(Tittle,Author,Quantity)values(@Tittle,@Author,@Quantity)";
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("MyConnection")))
            {
                SqlCommand cmd= new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Tittle", b.Tittle);
                cmd.Parameters.AddWithValue("@Author", b.Author);
                cmd.Parameters.AddWithValue("@Quantity", b.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
             
            }
            return Ok("Book Added Successfully");
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

        //[HttpGet("issue")]
        //public IActionResult IssuBook(IssuedBook IB)
        //{
        //    string query1 = "inert into students(Name,Email,Phone)values(@Name,@Email,@Phone)";
        //    string query2 = "inert into IssuedBooks(StudentId,BookId,IssuedId,Status)values(@StudentId,@BookId,@IssuedId,@Status)";
        //    using (SqlConnection con = new SqlConnection(_config.GetConnectionString("MyConnection")))
        //    {
        //        con.Open();
        //        SqlCommand cmd1 = new SqlCommand(query1, con);
        //        cmd1.Parameters.AddWithValue("@Tittle", IB.StudentId);
        //        int rows= cmd1.ExecuteNonQuery();
        //        if(rows==0)
        //            return BadRequest("Student Not Found");
        //        cmd1.Parameters.AddWithValue("@Author", IB.BookId);
        //        SqlCommand cmd2 = new SqlCommand(query2, con);

              

        //    }
        //    return Ok("Student Added Successfully");
        //}


    }
}
