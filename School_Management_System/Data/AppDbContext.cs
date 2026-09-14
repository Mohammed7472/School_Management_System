using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School_Management_System.Models;

namespace School_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SMS_Demo;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
