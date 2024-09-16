using Microsoft.EntityFrameworkCore;
using PortalAboutEverything.Data.Model;
using PortalAboutEverything.Data.Model.Alerts;


namespace PortalAboutEverything.Data
{
    public class PortalDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=Net16Portal";

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public PortalDbContext() { }
        public PortalDbContext(DbContextOptions<PortalDbContext> contextOptions) : base(contextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.FavoriteMovies)
                .WithMany(x => x.UsersWhoFavoriteTheMovie);

            modelBuilder.Entity<User>()
                .HasMany(x => x.AlertsWhichISaw)
                .WithOne(x => x.User);

            modelBuilder.Entity<Alert>()
                .HasMany(x => x.UsersWhoAlreadySawIt)
                .WithOne(x => x.Alert);

            base.OnModelCreating(modelBuilder);
        }
    }
}
