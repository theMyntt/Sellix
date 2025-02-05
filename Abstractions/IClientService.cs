using Sellix.DTOs;
using Sellix.DTOs.Response;

namespace Sellix.Abstractions
{
	public interface IClientService
	{
		Task<StandardResponse> InsertAsync(ClientDTO client);
		Task<StandardResponse> UpdateAsync(ClientDTO client, Guid id);
		Task<StandardResponse> DeleteAsync(Guid id);
		Task<FindClientsDTO> FindAsync(int page, int limit);
		Task<FindClientsDTO> FindAsync(string filter, int page, int limit);
	}
}
