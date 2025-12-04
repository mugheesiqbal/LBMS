namespace LBMS.Models
{
    public class IssueBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }  
        public Book Book { get; set; }
        public Student Student { get; set; }
    }
}
