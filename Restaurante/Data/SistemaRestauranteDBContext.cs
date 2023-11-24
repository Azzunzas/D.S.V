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
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Bebida> Bebidas { get; set;}
        public DbSet<Veiculo> Veiculos { get; set;}
        public DbSet<Mesa> Mesas { get; set;}
        public DbSet<Retirada> Retirada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    } 
}