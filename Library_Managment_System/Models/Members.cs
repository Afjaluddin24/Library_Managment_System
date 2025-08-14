using System.ComponentModel.DataAnnotations;

namespace Library_Managment_System.Models
{
    public class Members
    {
        public Members()
        {
            transactions = new HashSet<Transactions>();
        }
        [Key]
        public int member_id { get; set; }
        public string name { get; set; } = string.Empty; 
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public DateTime membership_date { get; set; } = DateTime.Now;

        public ICollection<Transactions> transactions { get; set; } 
    }
}
