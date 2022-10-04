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
        public DbSet<Mand> Manden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>()
                .HasOne(m => m.Mand)
                .WithMany(f => f.Fruit);
        }

    }
}
