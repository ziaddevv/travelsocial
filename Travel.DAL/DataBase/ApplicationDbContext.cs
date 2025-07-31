using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.DataBase
{
	public class ApplicationDbContext: DbContext
	{
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Places)
                .WithMany(p => p.Trips)
                .UsingEntity(j => j.ToTable("TripPlace"));


            modelBuilder.Entity<Review>()
                .HasOne(r => r.Place)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PlaceId);
        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
	
