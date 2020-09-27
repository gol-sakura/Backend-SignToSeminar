using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_SignToSeminar_WebApplication.Models;
using Backend_SignToSeminar_WebApplication.Controllers;

namespace Backend_SignToSeminar_WebApplication.Context
{
    public class StsDBContext : DbContext
    {
        public StsDBContext(DbContextOptions<StsDBContext> options) : base(options)
        {
        }
        public DbSet<Seminar> Seminars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Booking> Bookings { get; set; }


       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures One-to-many relationship
            modelBuilder.Entity<Seminar>()
                .HasMany(s => s.Bookings)
                .WithOne(b => b.Seminar)
                .IsRequired();


            //modelBuilder.Entity<Booking>()
            //   .HasRequired<Seminar>(b => b.Seminar)
            //   .WithMany(s => s.Bookings)
            //   .HasForeignKey<int>(b => b.SeminarId);
        }

    }
}
