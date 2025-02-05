using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sellix.Entities.Enums;

namespace Sellix.Entities
{
	[Table("Users")]
	public class UserEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		[Column("Password")]
		public string PasswordHash { get; set; } = string.Empty;

		[Column("Salt")]
		public string PasswordSalt { get; set; } = string.Empty;
		public bool IsBlocked { get; set; }
		public UserRole Role { get; set; }
	}
}

