// Aqui se agregan las configuraciones de las entidades y relaciones de la base de datos
// Ejemplo de configuración de una entidad:
// using agrisynth_backend.Collaboration.Domain.Model.Aggregates;

using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
namespace agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Terrain>().ToTable("Terrains");
        builder.Entity<Terrain>().HasKey(f => f.Id);
        builder.Entity<Terrain>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Terrain>().Property(f => f.Name).IsRequired();
        builder.Entity<Terrain>().Property(f => f.Description).IsRequired();
        builder.Entity<Terrain>().Property(f => f.Location).IsRequired();
        builder.Entity<Terrain>().Property(f => f.UsageClauses).IsRequired();
        builder.Entity<Terrain>().Property(f => f.SizeSquareMeters).IsRequired();
        builder.Entity<Terrain>().Property(f => f.Rent).IsRequired();
        builder.Entity<Terrain>().Property(f => f.ImageUrl).IsRequired();
        
       
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}