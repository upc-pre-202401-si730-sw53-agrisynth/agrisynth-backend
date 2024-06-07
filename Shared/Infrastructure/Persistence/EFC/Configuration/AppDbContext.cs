using agrisynth_backend.Landrental.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Aggregates;
using agrisynth_backend.Collaboration.Domain.Model.Entities;
using agrisynth_backend.Documents.Domain.Model.Aggregates;
using agrisynth_backend.Machineryrental.Domain.Model.Aggregates;
using agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace agrisynth_backend.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Terrains Context
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

            // Machinerys Context
            builder.Entity<Machinery>().ToTable("Machinerys");
            builder.Entity<Machinery>().HasKey(f => f.Id);
            builder.Entity<Machinery>().Property(f => f.Name).IsRequired();
            builder.Entity<Machinery>().Property(f => f.Price).IsRequired();
            builder.Entity<Machinery>().Property(f => f.ImageUrl).IsRequired();

            // Documents Context
            builder.Entity<Document>().ToTable("Documents");
            builder.Entity<Document>().HasKey(f => f.Id);
            builder.Entity<Document>().Property(f => f.Name).IsRequired();
            
            
            // Team Context
            builder.Entity<Team>().ToTable("Teams");
            builder.Entity<Team>().HasKey(t => t.Id);
            builder.Entity<Team>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Team>().Property(t => t.Name).IsRequired().HasMaxLength(100);

            // Worker Context
            builder.Entity<Worker>().ToTable("Workers");
            builder.Entity<Worker>().HasKey(w => w.Id);
            builder.Entity<Worker>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Worker>().Property(w => w.Name).IsRequired().HasMaxLength(100);

            // TeamWorker Context
            builder.Entity<TeamWorker>().ToTable("TeamWorkers");
            builder.Entity<TeamWorker>().HasKey(tw => tw.Id);
            builder.Entity<TeamWorker>().Property(tw => tw.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TeamWorker>().Property(tw => tw.TeamId).IsRequired();
            builder.Entity<TeamWorker>().Property(tw => tw.WorkerId).IsRequired();

            builder.Entity<TeamWorker>()
                .HasOne(tw => tw.Team)
                .WithMany()
                .HasForeignKey(tw => tw.TeamId);

            builder.Entity<TeamWorker>()
                .HasOne(tw => tw.Worker)
                .WithMany()
                .HasForeignKey(tw => tw.WorkerId);

            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TeamWorker> TeamWorkers { get; set; }
    }
}
