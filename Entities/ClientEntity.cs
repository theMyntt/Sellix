using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sellix.Entities.Enums;

namespace Sellix.Entities
{
	[Table("Clients")]
	public class ClientEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public ClientType Type { get; set; }

		public ClientEntity()
		{
		}
	}
}

