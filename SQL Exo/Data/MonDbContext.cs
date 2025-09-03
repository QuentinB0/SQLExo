using Microsoft.EntityFrameworkCore;
using SQL_Exo.Models;

namespace SQL_Exo.Data
{
    public class MonDbContext : DbContext
    {
        public MonDbContext(DbContextOptions<MonDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}