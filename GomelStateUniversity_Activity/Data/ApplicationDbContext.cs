using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            BuildCreativityTypes(modelBuilder);
            BuildLaborDirections(modelBuilder);
            BuildSportTypes(modelBuilder);
            BuildApplicationForms(modelBuilder);
            BuildSubdivisionActivityTypes(modelBuilder);
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
        private void BuildSubdivisionActivityTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubdivisionActivityType>(action =>
            {
                action.HasData(Data.SubdivisionActivityTypesDtoList);
            });
        }

        private void BuildApplicationForms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationForm>(action =>
            {
                action.Property(dto => dto.ApplicationParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);
            });
        }

        private static readonly ValueComparer DictionaryComparer =
            new ValueComparer<Dictionary<string, string>>(
                (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
                dictionary => dictionary.Aggregate(
                    0,
                    (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
                )
            );
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
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<SubdivisionActivityType> subdivisionActivityTypes { get; set; }
        
    }
}
