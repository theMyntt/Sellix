using System.Text.RegularExpressions;
using Sellix.Abstractions;
using Sellix.DTOs;
using Sellix.DTOs.Response;
using Sellix.Entities;

namespace Sellix.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repository;

		public ClientService(IClientRepository repository)
		{
			_repository = repository;
		}

		public async Task<StandardResponse> DeleteAsync(Guid id)
		{
			await _repository.DeleteAsync(id);

			return new StandardResponse
			{ 
				Message = "Deleted." ,
				StatusCode = 200
			};
		}

		public async Task<FindClientsDTO> FindAsync(int page, int limit)
		{
			return await _repository.FindAsync(page, limit);
		}

		public async Task<FindClientsDTO> FindAsync(string filter, int page, int limit)
		{
			return await _repository.FindAsync(filter, page, limit);
		}

		public async Task<StandardResponse> InsertAsync(ClientDTO client)
		{
			var name = Regex.Replace(client.Name, @"\s+", " ");

			var clientToPersistance = new ClientEntity
			{
				Id = Guid.NewGuid(),
				Name = name.Trim(),
				Email = client.Email.ToLower().Trim(),
				Phone = client.Phone.Trim(),
				Address = client.Address.ToUpper().Trim()
			};

			await _repository.InsertAsync(clientToPersistance);

			return new StandardResponse
			{
				Message = "Created.",
				StatusCode = 201
			};
		}

		public async Task<StandardResponse> UpdateAsync(ClientDTO client, Guid id)
		{
			var name = Regex.Replace(client.Name, @"\s+", " ");

			var clientToPersistance = new ClientEntity
			{
				Id = id,
				Name = name.Trim(),
				Email = client.Email.ToLower().Trim(),
				Phone = client.Phone.Trim(),
				Address = client.Address.ToUpper().Trim()
			};

			await _repository.UpdateAsync(clientToPersistance);

			return new StandardResponse
			{
				Message = "Updated.",
				StatusCode = 200
			};
		}
	}
}
