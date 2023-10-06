using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Data
{
    public class SistemaRestauranteDBContext : DbContext
    {
        public SistemaRestauranteDBContext(DbContextOptions<SistemaRestauranteDBContext>options)
            : base(options) 
        
        {    
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Pratos> Pratos { get; set; }
        public DbSet<Bebidas> Bebidas { get; set;}
        public DbSet<Veiculos> Veiculos { get; set;}
        public DbSet<Mesas> Mesas { get; set;}
        public DbSet<Retirada> Retirada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
