using System;
using Microsoft.EntityFrameworkCore;
using Sellix.Entities;

namespace Sellix.Context
{
	public class DatabaseContext : DbContext
	{
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<ClientEntity> Clients { get; set; }

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}
	}
}

