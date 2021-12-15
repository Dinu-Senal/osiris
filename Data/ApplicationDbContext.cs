﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Project>().HasMany(p => p.Sections);
            builder.Entity<Section>().HasMany(p => p.Tickets);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
