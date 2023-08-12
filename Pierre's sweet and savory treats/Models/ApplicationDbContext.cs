using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Models;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Pierre_s_sweet_and_savory_treats.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<TreatFlavor> TreatFlavors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define entity relationships and configurations here
            modelBuilder.Entity<TreatFlavor>()
                .HasKey(tf => new { tf.TreatId, tf.FlavorId });

            modelBuilder.Entity<TreatFlavor>()
                .HasOne(tf => tf.Treat)
                .WithMany(t => t.TreatFlavors)
                .HasForeignKey(tf => tf.TreatId);

            modelBuilder.Entity<TreatFlavor>()
                .HasOne(tf => tf.Flavor)
                .WithMany(f => f.TreatFlavors)
                .HasForeignKey(tf => tf.FlavorId);
        }
    }
}
