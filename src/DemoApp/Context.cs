using DemoApp.Stations.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoApp
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        private DbSet<Station> Stations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Station
            modelBuilder.Entity<Station>()
                .ToTable("Stations")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Station>()
                .HasMany<Sensor>(x => x.Sensors).WithOne(x => x.Station).OnDelete(DeleteBehavior.Cascade);

            // Sensor
            modelBuilder.Entity<Sensor>()
                .ToTable("Sensors")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Sensor>()
                .HasMany<SensorData>(x => x.Data).WithOne(x => x.Sensor).OnDelete(DeleteBehavior.Cascade);

            // SensorData
            modelBuilder.Entity<SensorData>()
                .ToTable("SensorData")
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}