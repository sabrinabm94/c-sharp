using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Itens { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.id);
            modelBuilder.Entity<Order>().HasKey(p => p.id);
            modelBuilder.Entity<OrderItem>().HasKey(p => p.id);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
