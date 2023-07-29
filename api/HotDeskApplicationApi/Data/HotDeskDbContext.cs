using System;
using HotDeskApplicationApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Data
{
	public class HotDeskDbContext : IdentityDbContext
	{
        public DbSet<Models.Profile> Profile { get; set; } = default!;
        public DbSet<Models.Reservation> Reservations { get; set; } = default!;
        public DbSet<Models.Office> Offices { get; set; } = default!;
        public DbSet<Models.Floor> Floors { get; set; } = default!;
        public DbSet<Models.Desk> Desks { get; set; } = default!;

        public HotDeskDbContext(DbContextOptions<HotDeskDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Models.Profile>()
                .HasKey(nameof(Models.Profile.ID));

            modelBuilder
                .Entity<Models.Reservation>()
                .HasKey(r => r.ID);

            modelBuilder
                .Entity<Models.Office>()
                .HasKey(o => o.ID);

            modelBuilder
                .Entity<Models.Floor>()
                .HasKey(f => f.ID);

            modelBuilder
                .Entity<Models.Desk>()
                .HasKey(d => d.ID);

            base.OnModelCreating(modelBuilder);

           
        }
    }
}

