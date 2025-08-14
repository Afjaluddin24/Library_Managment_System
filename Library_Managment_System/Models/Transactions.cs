using System.ComponentModel.DataAnnotations;

namespace Library_Managment_System.Models
{
    public class Transactions
    {
        [Key]
        public int transaction_id { get; set; } 
        public int? member_id { get; set; } 
        public Members? member { get; set; }  
        public int? book_id { get; set; }
        public Books? book { get; set; }
        public DateTime issue_date { get; set; } = DateTime.Now;
        public DateTime due_date { get; set; } = DateTime.Now;
        public DateTime? return_date { get; set; } 
        public string? status { get; set; } 
    }
}
