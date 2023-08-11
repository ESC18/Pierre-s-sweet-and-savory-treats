using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PierreTreats.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Treat> Treats { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<TreatFlavor> TreatFlavors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TreatFlavor>()
                .HasKey(tf => new { tf.TreatId, tf.FlavorId });

            // ... Other configurations
        }
    }
}
