using System;
using System.Security.Cryptography;
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

            Guid PredealID = Guid.NewGuid();
            Guid BrizeiID = Guid.NewGuid();

            Office[] offices = new Office[2]
            {
                new Office { ID = PredealID, Name = "Predeal" },
                new Office { ID = BrizeiID, Name = "Brizei" }
            };

            modelBuilder.Entity<Models.Office>().HasData(offices);

            Guid PGroundFloor = Guid.NewGuid();
            Guid PFloor1 = Guid.NewGuid();
            Guid PFloor2 = Guid.NewGuid();
            Guid BFloor1 = Guid.NewGuid();
            Guid BFloor2 = Guid.NewGuid();

            Floor[] floors = new Floor[5]
            {
                new Floor { ID = PGroundFloor, Name = "Ground Floor", OfficeID = PredealID },
                new Floor { ID = PFloor1, Name = "Floor 1", OfficeID = PredealID },
                new Floor { ID = PFloor2, Name = "Floor 2", OfficeID = PredealID },
                new Floor { ID = BFloor1, Name = "Floor 1", OfficeID = BrizeiID },
                new Floor { ID = BFloor2, Name = "Floor 2", OfficeID = BrizeiID },
            };

            modelBuilder.Entity<Models.Floor>().HasData(floors);

            Guid PP1 = Guid.NewGuid();
            Guid PP2 = Guid.NewGuid();
            Guid PP3 = Guid.NewGuid();
            Guid PP4 = Guid.NewGuid();
            Guid PP5 = Guid.NewGuid();
            Guid PE11 = Guid.NewGuid();
            Guid PE12 = Guid.NewGuid();
            Guid PE13 = Guid.NewGuid();
            Guid PE14 = Guid.NewGuid();
            Guid PE21 = Guid.NewGuid();
            Guid PE22 = Guid.NewGuid();
            Guid PE23 = Guid.NewGuid();
            Guid PE24 = Guid.NewGuid();
            Guid BE13 = Guid.NewGuid();
            Guid BE14 = Guid.NewGuid();
            Guid BE21 = Guid.NewGuid();
            Guid BE22 = Guid.NewGuid();
            Guid BE23 = Guid.NewGuid();
            Guid BE24 = Guid.NewGuid();

            Desk[] desks = new Desk[19]
            {
                new Desk  { ID = PP1, Name = "PP1", FloorID = PGroundFloor, OfficeID = PredealID },
                new Desk  { ID = PP2, Name = "PP2", FloorID = PGroundFloor, OfficeID = PredealID },
                new Desk  { ID = PP3, Name = "PP3", FloorID = PGroundFloor, OfficeID = PredealID },
                new Desk  { ID = PP4, Name = "PP4", FloorID = PGroundFloor, OfficeID = PredealID },
                new Desk  { ID = PP5, Name = "PP5", FloorID = PGroundFloor, OfficeID = PredealID },
                new Desk  { ID = PE11, Name = "PE11", FloorID = PFloor1, OfficeID = PredealID },
                new Desk  { ID = PE12, Name = "PE12", FloorID = PFloor1, OfficeID = PredealID },
                new Desk  { ID = PE13, Name = "PE13", FloorID = PFloor1, OfficeID = PredealID },
                new Desk  { ID = PE14, Name = "PE14", FloorID = PFloor1, OfficeID = PredealID },
                new Desk  { ID = PE21, Name = "PE21", FloorID = PFloor2, OfficeID = PredealID },
                new Desk  { ID = PE22, Name = "PE22", FloorID = PFloor2, OfficeID = PredealID },
                new Desk  { ID = PE23, Name = "PE23", FloorID = PFloor2, OfficeID = PredealID },
                new Desk  { ID = PE24, Name = "PE24", FloorID = PFloor2, OfficeID = PredealID },
                new Desk  { ID = BE13, Name = "BE13", FloorID = BFloor1, OfficeID = BrizeiID },
                new Desk  { ID = BE14, Name = "BE14", FloorID = BFloor1, OfficeID = BrizeiID },
                new Desk  { ID = BE21, Name = "BE21", FloorID = BFloor2, OfficeID = BrizeiID },
                new Desk  { ID = BE22, Name = "BE22", FloorID = BFloor2, OfficeID = BrizeiID },
                new Desk  { ID = BE23, Name = "BE23", FloorID = BFloor2, OfficeID = BrizeiID },
                new Desk  { ID = BE24, Name = "BE24", FloorID = BFloor2, OfficeID = BrizeiID },
             };

            modelBuilder.Entity<Models.Desk>().HasData(desks);

        }
    }
}

