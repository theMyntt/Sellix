using System;
using Microsoft.EntityFrameworkCore;
using Sellix.Entities;

namespace Sellix.Context
{
	public class DatabaseContext : DbContext
	{
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<ClientEntity> Clients { get; set; }
		public DbSet<SaleEntity> Sales { get; set; }

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SaleEntity>()
				.HasOne(u => u.Client)
				.WithMany()
				.HasForeignKey(u => u.ClientId);

			modelBuilder.Entity<SaleEntity>()
				.HasOne(u => u.User)
				.WithMany()
				.HasForeignKey(u => u.UserId);

			base.OnModelCreating(modelBuilder);
		}
	}
}

