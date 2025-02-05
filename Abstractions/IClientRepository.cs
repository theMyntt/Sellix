using Sellix.DTOs.Response;
using Sellix.Entities;

namespace Sellix.Abstractions
{
	public interface IClientRepository
	{
		Task InsertAsync(ClientEntity entity);
		Task UpdateAsync(ClientEntity entity);
		Task DeleteAsync(Guid id);
		Task<FindClientsDTO> FindAsync(int page, int limit);
		Task<FindClientsDTO> FindAsync(string filter, int page, int limit);
	}
}
