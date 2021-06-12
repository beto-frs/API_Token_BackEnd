using Microsoft.EntityFrameworkCore;
using projeto.api.Business.Entities;
using projeto.api.Infraestruture.Data.Mappings;

namespace projeto.api.Infraestruture.Data
{
    public class ProjetoDbContext : DbContext
    {
        public ProjetoDbContext(DbContextOptionsBuilder<ProjetoDbContext> options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
    }

}
