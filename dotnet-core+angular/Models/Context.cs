using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Model
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.id);
            modelBuilder.Entity<Account>().HasKey(p => p.id);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
