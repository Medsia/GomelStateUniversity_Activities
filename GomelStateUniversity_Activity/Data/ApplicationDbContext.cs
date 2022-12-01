using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GomelStateUniversity_Activity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildEventUsers(modelBuilder);
            BuildSubdivisions(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void BuildSubdivisions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subdivision>(action =>
            {
                action.HasData(Data.SubdivisionDtoList);
            });
        }
        private void BuildEventUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUser>()
                .HasKey(t => new { t.EventId, t.ApplicationUserId });
            modelBuilder.Entity<EventUser>()
                .HasOne(sc => sc.Event)
                .WithMany(s => s.EventUsers)
                .HasForeignKey(sc => sc.EventId);
            modelBuilder.Entity<EventUser>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany(s => s.EventUsers)
                .HasForeignKey(sc => sc.ApplicationUserId);
        }
        private void BuildCreativityTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreativityType>(action =>
            {
                action.HasData(Data.CreativityTypesDtoList);
            });
        }
        private void BuildLaborDirections(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaborDirection>(action =>
            {
                action.HasData(Data.LaborDirectionsDtoList);
            });
        }
        private void BuildSportTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportType>(action =>
            {
                action.HasData(Data.SportTypesDtoList);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<ScheduleItem> Schedule { get; set; }
        public DbSet<CreativityType> CreativityTypes { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<LaborDirection> LaborDirections { get; set; }
    }
}
