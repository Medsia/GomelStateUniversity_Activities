using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GomelStateUniversity_Activity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUsers>()
                .HasKey(t => new { t.EventId, t.ApplicationUserId});
            modelBuilder.Entity<EventUsers>()
                .HasOne(sc => sc.Event)
                .WithMany(s => s.EventUsers)
                .HasForeignKey(sc => sc.EventId);
            modelBuilder.Entity<EventUsers>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany(s => s.EventUsers)
                .HasForeignKey(sc => sc.ApplicationUserId);
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
