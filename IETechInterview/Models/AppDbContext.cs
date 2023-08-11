using Microsoft.EntityFrameworkCore;

namespace IETechInterview.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet< Employees> Employees{ get; set; }
        public DbSet<LoginViewModel> Users { get; set; }
    }
}
