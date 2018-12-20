using Microsoft.EntityFrameworkCore;
using MyWebApp.Model;

namespace MyWebApp.Model
{
    public class Context : DbContext
    {
        public DbSet<Agencia> agencias { get; set; }
        public DbSet<CartaoCredito> cartaoCreditos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Conta> contas { get; set; }
        public DbSet<Filial> filiais { get; set; }
        public DbSet<Grupo> grupos { get; set; }
        public DbSet<Movimento> movimentos { get; set; }
        public DbSet<TipoConta> tipoContas { get; set; }
        public DbSet<TipoMovimento> tipoMovimentos { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>().HasKey(p => p.AgenciaCodigo);
            modelBuilder.Entity<CartaoCredito>().HasKey(p => p.CartaoCreditoCodigo);
            modelBuilder.Entity<Cliente>().HasKey(p => p.ClienteCodigo);
            modelBuilder.Entity<Conta>().HasKey(p => p.ContaCodigo);
            modelBuilder.Entity<Filial>().HasKey(p => p.FilialCodigo);
            modelBuilder.Entity<Grupo>().HasKey(p => p.GrupoCodigo);
            modelBuilder.Entity<Movimento>().HasKey(p => p.MovimentoCodigo);
            modelBuilder.Entity<TipoConta>().HasKey(p => p.TipoContaCodigo);
            modelBuilder.Entity<TipoMovimento>().HasKey(p => p.TipoMovimentoCodigo);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
