using IVS_RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace IVS_RazorPages.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
