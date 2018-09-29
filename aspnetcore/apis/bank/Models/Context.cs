using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CashMachine> CashMachines { get; set; }
        public DbSet<MoneyBill> MoneyBills { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.id);
            modelBuilder.Entity<Account>().HasKey(p => p.id);
            modelBuilder.Entity<CashMachine>().HasKey(p => p.id);
            modelBuilder.Entity<MoneyBill>().HasKey(p => p.id);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
