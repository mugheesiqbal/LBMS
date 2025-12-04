using LBMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LBMS.Data
{
    public class LibrayContext : DbContext
    {
        public LibrayContext(DbContextOptions<LibrayContext> options) : base(options) { }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
       
        }

       
        
    }

