﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cs_Risk_Assessment.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Assessment> Assessments { get; set; }
		public DbSet<Threat> Threats { get; set; }
		public DbSet<Asset> Assets { get; set; }
		public DbSet<Vulnerability> Vulnerabilities { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>()
				.Property(u => u.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDefaultValue(null)
				.IsConcurrencyToken();
			modelBuilder.Entity<ApplicationUser>()
				.Property(u => u.OrganizationType)
				.IsRequired()
				.HasMaxLength(256)
				.HasDefaultValue(null)
				.IsConcurrencyToken();
			modelBuilder.Entity<ApplicationUser>()
				.Property(u => u.OrganizationName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDefaultValue(null)
				.IsConcurrencyToken();
			modelBuilder.Entity<ApplicationUser>()
				.Property(u => u.Country)
				.IsRequired()
				.HasMaxLength(256)
				.HasDefaultValue(null)
				.IsConcurrencyToken();


		}
	}

}
