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

            Guid PredealID = Guid.Parse("006E9D57-99D2-40B2-B0E1-DB7197B226D5");
            Guid BrizeiID = Guid.Parse("DD02E05A-449D-4438-B84A-2CDEE7B5069E");

            Office[] offices = new Office[2]
            {
                new Office { ID = PredealID, Name = "Predeal" },
                new Office { ID = BrizeiID, Name = "Brizei" }
            };

            modelBuilder.Entity<Models.Office>().HasData(offices);

            Guid PGroundFloor = Guid.Parse("37BB197B-7D02-4C81-A4B1-FCE0E4D06F83");
            Guid PFloor1 = Guid.Parse("6DA51987-FEE8-4804-98FD-6945051172BD");
            Guid PFloor2 = Guid.Parse("8D57830B-0090-4B5B-AEEA-A72197D8A250");
            Guid BFloor1 = Guid.Parse("55529EB0-D278-4681-80FE-41C7E738D7A5");
            Guid BFloor2 = Guid.Parse("85F71447-FDDC-4DC3-ACDF-2C4C15DE0A19");

            Floor[] floors = new Floor[5]
            {
                new Floor { ID = PGroundFloor, Name = "Ground Floor", OfficeID = PredealID },
                new Floor { ID = PFloor1, Name = "Floor 1", OfficeID = PredealID },
                new Floor { ID = PFloor2, Name = "Floor 2", OfficeID = PredealID },
                new Floor { ID = BFloor1, Name = "Floor 1", OfficeID = BrizeiID },
                new Floor { ID = BFloor2, Name = "Floor 2", OfficeID = BrizeiID },
            };

            modelBuilder.Entity<Models.Floor>().HasData(floors);

            Guid PP1 = Guid.Parse("5B433AEC-54EA-4E04-9447-4D65C47F4BF8");
            Guid PP2 = Guid.Parse("926C8AFD-EE70-4372-ADD5-6320AB116F5F");
            Guid PP3 = Guid.Parse("DF83C7C0-C202-4D9E-8005-CB3296439781");
            Guid PP4 = Guid.Parse("D70DF64B-6E1A-4B69-8CDB-DF279C48B2B7");
            Guid PP5 = Guid.Parse("8FF579A9-1016-4EE0-8AE9-3FE6915E0A48");
            Guid PE11 = Guid.Parse("72AE4345-2CDE-4E22-A09D-944499F47163");
            Guid PE12 = Guid.Parse("61A6A913-DF3B-454C-9DDE-230B60EA058C");
            Guid PE13 = Guid.Parse("4DC84B09-95FD-4F90-9025-2255712F31F2");
            Guid PE14 = Guid.Parse("BAC4DA7A-2B44-4FF1-B37E-BC62E4791462");
            Guid PE21 = Guid.Parse("293D81C0-B316-4FDE-8BA4-AEB71725C9D8");
            Guid PE22 = Guid.Parse("3393EB3C-7A39-4DA9-91CC-23EFDFC2B27C");
            Guid PE23 = Guid.Parse("3F2F7B67-5CCE-4338-8A52-2D33210AC4F2");
            Guid PE24 = Guid.Parse("0A05ED78-D5F4-4BB4-A100-FF85CC54B9F7");
            Guid BE13 = Guid.Parse("07ACF76C-87E8-4DB0-9BD9-C0A93CE5DC8C");
            Guid BE14 = Guid.Parse("6307EFAD-0EA0-4342-99D4-402D67180319");
            Guid BE21 = Guid.Parse("85B363A3-C052-4BA2-A466-0E9F6D485248");
            Guid BE22 = Guid.Parse("2704C4EB-DFFA-4C34-9908-EFA5C003AC8D");
            Guid BE23 = Guid.Parse("9395C4B8-CA8A-4E74-A725-5FFC4C50C12E");
            Guid BE24 = Guid.Parse("A220DE6A-F999-45A4-AE28-A503AA49F9EA");

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

