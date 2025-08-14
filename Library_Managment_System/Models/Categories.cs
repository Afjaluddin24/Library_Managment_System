using System.ComponentModel.DataAnnotations;

namespace Library_Managment_System.Models
{
    public class Categories
    {
        public Categories()
        {
            Books = new HashSet<Books>();
        }
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; } = string.Empty;

        public ICollection<Books> Books { get; set; }
    }
}
