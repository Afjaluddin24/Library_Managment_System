using System.ComponentModel.DataAnnotations;

namespace Library_Managment_System.Models
{
    public class Staff
    {
        public Staff()
        {
            transactions = new HashSet<Transactions>();
        }

        [Key]
        public int staff_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public ICollection<Transactions> transactions { get; set; }
    }
}
