using Sellix.Entities;

namespace Sellix.DTOs.Response
{
	public class FindClientsDTO
	{
		public IEnumerable<ClientEntity> Clients { get; set; } = new List<ClientEntity>();
		public int TotalPages { get; set; }
		public int TotalClients { get; set; }
		public int Page { get; set; }
	}
}
