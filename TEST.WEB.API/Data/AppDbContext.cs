using Microsoft.EntityFrameworkCore;
using TEST.WEB.API.Models;

namespace TEST.WEB.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
