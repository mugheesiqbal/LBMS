using LBMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace LBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnBookController : ControllerBase
    {
       private  readonly IConfiguration _config;

       public ReturnBookController(IConfiguration config)
        {
               _config = config;
        }

        [HttpGet("return/{IssuedId}")]
       
             public IActionResult ReturnBook(int IssuedId)
        {
            string query1 = "update IssuedBook set RetuenDate=GetDate(), Status='Returned' IssuedId=@IssuedId";
            string query2 = "update Books set Quantity=Quantity+1 where BookId=(select BookId from IssuedBook where IssueId=@IssuedId)";
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("MyConnection")))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@IssuedId", IssuedId);
                cmd1.ExecuteNonQuery();
                
                cmd1.Parameters.AddWithValue("@IssuedId", IssuedId);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();


            }

            // Logic for returning a book will be implemented here in the future.
            return Ok("Return Book endpoint is under construction.");
        }
    }
}
