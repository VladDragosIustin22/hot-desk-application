using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Data
{
	public class ProfileContext : IdentityDbContext
	{
        public DbSet<Models.Profile> Profile { get; set; } = default!;

        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Models.Profile>()
                .HasKey(nameof(Models.Profile.ID));
        }
    }
}

