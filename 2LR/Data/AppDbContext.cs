using System.CodeDom;
using System.Security.Cryptography.X509Certificates;
using _2LR.Models;
using Microsoft.EntityFrameworkCore;


namespace _2LR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
