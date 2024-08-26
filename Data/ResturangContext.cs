using Microsoft.EntityFrameworkCore;
using ResturangSystem.Models;

namespace ResturangSystem.Data
{
    public class ResturangContext : DbContext
    {
        public ResturangContext(DbContextOptions<ResturangContext> options) : base(options)
        {
        }

        public DbSet<ResturangSystem.Models.Bord> Bord { get; set; }
        public DbSet<ResturangSystem.Models.Bokning> Bokning { get; set; }
        public DbSet<ResturangSystem.Models.Kund> Kund { get; set; }
        public DbSet<ResturangSystem.Models.Meny> Meny { get; set; }
        public DbSet<ResturangSystem.Models.Restaurang> Restaurang { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Seed data
            modelBuilder.Entity<Restaurang>().HasData(
                new Restaurang { RestaurangId = 1, Namn = "Restaurang A" },
                new Restaurang { RestaurangId = 2, Namn = "Restaurang B" }
            );

            modelBuilder.Entity<Bord>().HasData(
                new Bord { BordId = 1, Bordsnummer = 101, Platser = 4, BoolBokad = false, RestaurangId = 1 },
                new Bord { BordId = 2, Bordsnummer = 102, Platser = 2, BoolBokad = false, RestaurangId = 1 },
                new Bord { BordId = 3, Bordsnummer = 201, Platser = 4, BoolBokad = false, RestaurangId = 2 }
            );

            modelBuilder.Entity<Kund>().HasData(
                new Kund { KundId = 1, Namn = "Kund A", Email = "kunda@example.com" },
                new Kund { KundId = 2, Namn = "Kund B", Email = "kundb@example.com" }
            );

            modelBuilder.Entity<Bokning>().HasData(
                new Bokning { BokningId = 1, Datum = DateTime.Now.AddDays(1), Antal = 2, KundId = 1, BordId = 1 },
                new Bokning { BokningId = 2, Datum = DateTime.Now.AddDays(2), Antal = 4, KundId = 2, BordId = 3 }
            );

            modelBuilder.Entity<Meny>().HasData(
                new Meny { MenyId = 1, Namn = "Rätt A", Pris = 100m, Tillgänglig = true, RestaurangId = 1 },
                new Meny { MenyId = 2, Namn = "Rätt B", Pris = 150m, Tillgänglig = false, RestaurangId = 1 },
                new Meny { MenyId = 3, Namn = "Rätt C", Pris = 120m, Tillgänglig = true, RestaurangId = 2 }
            );
        }
    }
}
