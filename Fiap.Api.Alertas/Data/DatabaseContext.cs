using Fiap.Api.Alertas.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alertas.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<AlertaModel> Alertas { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected DatabaseContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertaModel>(entity =>
            {
                entity.ToTable("Alertas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired();
                entity.Property(e => e.Descricao).IsRequired();
                entity.Property(e => e.Risco).IsRequired();
                entity.Property(e => e.Situacao).IsRequired();
                entity.Property(e => e.DataAlerta).HasColumnType("date");
                entity.Property(e => e.Categoria).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
