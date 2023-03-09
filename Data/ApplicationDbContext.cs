using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektV3.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjektV3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.Registrations).WithOne(p => p.User).HasForeignKey(p => p.IdPatient);

            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Doctor>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Doctor>().HasMany(p => p.Registrations).WithOne(p => p.Doctor).HasForeignKey(p => p.IdDoctor);
            modelBuilder.Entity<Doctor>().HasMany(p => p.WorkingHours).WithOne(p => p.Doctor).HasForeignKey(p => p.IdDoctor);

            modelBuilder.Entity<Registration>().ToTable("Registrations");
            modelBuilder.Entity<Registration>().Property(p => p.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Registration>().Property(p => p.IdPatient).IsRequired(false);
            modelBuilder.Entity<Registration>().HasOne(p => p.Doctor).WithMany(p => p.Registrations);
            modelBuilder.Entity<Registration>().HasOne(p => p.User).WithMany(p => p.Registrations);

            modelBuilder.Entity<WorkingHour>().ToTable("WorkingHours");
            modelBuilder.Entity<WorkingHour>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<WorkingHour>().HasOne(p => p.Doctor).WithMany(p => p.WorkingHours);
        }
            public DbSet<ApplicationUser> Users { get; set; }
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Registration> Registrations { get; set; }
            public DbSet<WorkingHour> WorkingHours { get; set; }
    
        
    }
}
