using Microsoft.EntityFrameworkCore;
using NodeApplication.Models;

namespace NodeApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Node> nodes { get; set; }

        

    }
}
