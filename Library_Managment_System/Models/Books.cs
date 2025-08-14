using System.ComponentModel.DataAnnotations;

namespace Library_Managment_System.Models
{
    public class Books
    {
        public Books()
        {
            transactions = new HashSet<Transactions>();
        }

        [Key]
        public int book_id { get; set; }
        public string title { get; set; } = string.Empty; 
        public string author { get; set; } = string.Empty;
        public string publisher { get; set; } = string.Empty;
        public string isbn { get; set; } = string.Empty;
        public int category_id { get; set; }
        public Categories? Category { get; set; }
        public int available_copies { get; set; }
        public ICollection<Transactions> transactions { get; set; } 
    }
}
