using Library_Managment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.ApplicationContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Transactions>Transactions { get; set; }
        public DbSet<Staff> Staffs { get; set; }

    }
}
