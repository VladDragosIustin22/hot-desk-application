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

            string PredealID = "633fab52-a103-44a2-abf7-3639249d61fd";
            string BrizeiID = "21e7299d-6887-4585-8550-cc5c9961b397";

            Office[] offices = new Office[2]
            {
                new Office { ID = Guid.Parse(PredealID), Name = "Predeal" },
                new Office { ID = Guid.Parse(BrizeiID), Name = "Brizei" }
            };

            modelBuilder.Entity<Models.Office>().HasData(offices);

            string PGroundFloor = "944E1316-5D1D-4A82-9148-3805252AF5C3";
            string PFloor1 = "C3CD5EF0-6A31-4F41-B865-4AF13BA23EE3";
            string PFloor2 = "ADC20BA6-0036-4FD6-83CA-7D620E98F9BD";
            string BFloor1 = "57B3201B-0FE4-4B5B-8544-E5044173ED2A";
            string BFloor2 = "6FF878BC-C827-4D9E-B892-BDE6EBF3A55D";

            Floor[] floors = new Floor[5]
            {
                new Floor { ID = Guid.Parse(PGroundFloor), Name = "Ground Floor", OfficeID = Guid.Parse(PredealID) },
                new Floor { ID = Guid.Parse(PFloor1), Name = "Floor 1", OfficeID = Guid.Parse(PredealID) },
                new Floor { ID = Guid.Parse(PFloor2), Name = "Floor 2", OfficeID = Guid.Parse(PredealID) },
                new Floor { ID = Guid.Parse(BFloor1), Name = "Floor 1", OfficeID = Guid.Parse(BrizeiID) },
                new Floor { ID = Guid.Parse(BFloor2), Name = "Floor 2", OfficeID = Guid.Parse(BrizeiID) },
            };

            modelBuilder.Entity<Models.Floor>().HasData(floors);

            string PP1 = "F1890E2C-9F87-49F2-9358-4FC8473F6859";
            string PP2 = "AB3765A1-DDE6-44BA-97A2-CF9A9A8E79A9";
            string PP3 = "F7BCC4F7-8B8E-4D34-ACA4-CA0FDD4B7348";
            string PP4 = "7F8B59BF-AC5A-4040-B5E5-9EDA3FB2A479";
            string PP5 = "098B1240-A79F-4D15-88FE-EA86FFB7FB38";
            string PE11 = "2129ADBD-CCC5-49F6-B3AE-2A51CAAF325B";
            string PE12 = "C9A1288C-9E3C-42E8-98FA-E78CFD57CAD3";
            string PE13 = "E45B99B5-C5B9-4EFE-8C35-9A79D4E3B72D";
            string PE14 = "6EE58175-299F-41ED-8B8F-045FC52B8838";
            string PE21 = "E2B2A7FA-B035-456D-A327-1812145F734B";
            string PE22 = "388CF175-973F-4ED0-8E57-CC169156ED90";
            string PE23 = "67C0077B-388A-4B7F-B1FF-F7EECEAEFCF6";
            string PE24 = "10F4EE17-A519-49F3-B77E-4E94FDD462EE";
            string BE13 = "0D031233-488D-42F3-BC5A-5B4B0E31D959";
            string BE14 = "7BAD3DD6-41B6-42F9-82A0-59E00F12E25A";
            string BE21 = "D43023E1-B793-4999-949D-1EE7FC9258E2";
            string BE22 = "5D857FA8-B520-4DC7-B9CF-BF3E825B8275";
            string BE23 = "381BD954-BE9E-4AD2-9868-D5A12625E8AB";
            string BE24 = "C66FE525-FD35-4EDD-9B20-5AA45EFF8B01";

            Desk[] desks = new Desk[19]
            {
                new Desk  { ID = Guid.Parse(PP1), Name = "PP1", FloorID = Guid.Parse(PGroundFloor) },
                new Desk  { ID = Guid.Parse(PP2), Name = "PP2", FloorID = Guid.Parse(PGroundFloor) },
                new Desk  { ID = Guid.Parse(PP3), Name = "PP3", FloorID = Guid.Parse(PGroundFloor) },
                new Desk  { ID = Guid.Parse(PP4), Name = "PP4", FloorID = Guid.Parse(PGroundFloor) },
                new Desk  { ID = Guid.Parse(PP5), Name = "PP5", FloorID = Guid.Parse(PGroundFloor) },
                new Desk  { ID = Guid.Parse(PE11), Name = "PE11", FloorID = Guid.Parse(PFloor1) },
                new Desk  { ID = Guid.Parse(PE12), Name = "PE12", FloorID = Guid.Parse(PFloor1) },
                new Desk  { ID = Guid.Parse(PE13), Name = "PE13", FloorID = Guid.Parse(PFloor1) },
                new Desk  { ID = Guid.Parse(PE14), Name = "PE14", FloorID = Guid.Parse(PFloor1) },
                new Desk  { ID = Guid.Parse(PE21), Name = "PE21", FloorID = Guid.Parse(PFloor2) },
                new Desk  { ID = Guid.Parse(PE22), Name = "PE22", FloorID = Guid.Parse(PFloor2) },
                new Desk  { ID = Guid.Parse(PE23), Name = "PE23", FloorID = Guid.Parse(PFloor2) },
                new Desk  { ID = Guid.Parse(PE24), Name = "PE24", FloorID = Guid.Parse(PFloor2) },
                new Desk  { ID = Guid.Parse(BE13), Name = "BE13", FloorID = Guid.Parse(BFloor1) },
                new Desk  { ID = Guid.Parse(BE14), Name = "BE14", FloorID = Guid.Parse(BFloor1) },
                new Desk  { ID = Guid.Parse(BE21), Name = "BE21", FloorID = Guid.Parse(BFloor2) },
                new Desk  { ID = Guid.Parse(BE22), Name = "BE22", FloorID = Guid.Parse(BFloor2) },
                new Desk  { ID = Guid.Parse(BE23), Name = "BE23", FloorID = Guid.Parse(BFloor2) },
                new Desk  { ID = Guid.Parse(BE24), Name = "BE24", FloorID = Guid.Parse(BFloor2) },
             };

            modelBuilder.Entity<Models.Desk>().HasData(desks);

        }
    }
}

