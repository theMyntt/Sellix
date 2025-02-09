using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sellix.Entities.Enums;

namespace Sellix.Entities
{
	[Table("Sales")]
	public class SaleEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string Product { get; set; } = string.Empty;
		public Guid ClientId { get; set; }
		public Guid UserId { get; set; }
		public SaleStatus SaleStatus { get; set; }

		public UserEntity User { get; set; }
		public ClientEntity Client { get; set; }

		public SaleEntity()
		{
		}
	}
}

