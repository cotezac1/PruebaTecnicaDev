using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Models;

namespace PruebaTecnica.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } 
    public DbSet<Pais> Paises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.ToTable("Paises");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<ClienteConPaisDto>(entity =>
        {
            entity.HasNoKey(); 
            entity.ToView(null); 
        });
    }
}