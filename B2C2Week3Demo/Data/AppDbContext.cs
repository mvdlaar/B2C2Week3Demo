using B2C2Week3Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace B2C2Week3Demo.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions): base(contextOptions)
        {

        }

        public DbSet<Fruit> Fruits { get; set; }
    }
}
