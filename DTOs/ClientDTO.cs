using Sellix.Entities.Enums;

namespace Sellix.DTOs
{
	public class ClientDTO
	{
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public ClientType Type { get; set; }
	}
}
