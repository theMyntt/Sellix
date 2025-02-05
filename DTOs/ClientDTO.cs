using System.ComponentModel.DataAnnotations;
using Sellix.Entities.Enums;

namespace Sellix.DTOs
{
	public class ClientDTO
	{
		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string Phone { get; set; } = string.Empty;

		[Required]
		public string Address { get; set; } = string.Empty;

		[Required]
		public ClientType Type { get; set; }
	}
}
