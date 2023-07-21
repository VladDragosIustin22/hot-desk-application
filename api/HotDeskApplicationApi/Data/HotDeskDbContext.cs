using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotDeskApplicationApi.Data
{
	public class HotDeskDbContext : IdentityDbContext
	{
        public DbSet<Models.Profile> Profile { get; set; } = default!;

        public HotDeskDbContext(DbContextOptions<HotDeskDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

