using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sellix.Abstractions;
using Sellix.Context;
using Sellix.DTOs.Response;
using Sellix.Entities;
using Sellix.Exceptions;

namespace Sellix.Repositories
{
	public class ClientRepository : IClientRepository
	{
		private readonly DatabaseContext _context;

		public ClientRepository(DatabaseContext context)
		{
			_context = context;
		}

		public async Task DeleteAsync(Guid id)
		{
			var client = await _context.Clients.FindAsync(id);

			if (client == null)
				throw new NotFoundException("Client not exists.");

			_context.Clients.Remove(client);
			
			await _context.SaveChangesAsync();
		}

		public async Task<FindClientsDTO> FindAsync(int page, int limit)
		{
			var offset = (page - 1) * limit;

			var clients = await _context.Clients
				.Skip(offset)
				.Take(limit)
				.ToListAsync();

			var totalClients = await _context.Clients.CountAsync();
			var totalPages = (int) Math.Ceiling((double)totalClients / limit);

			return new FindClientsDTO
			{
				Clients = clients,
				TotalClients = totalClients,
				TotalPages = totalPages,
				Page = page
			};
		}

		public async Task<FindClientsDTO> FindAsync(string filter, int page, int limit)
		{
			Expression<Func<ClientEntity, bool>> bruteFilter = c =>
				c.Name.Contains(filter) ||
				c.Email.Contains(filter) ||
				c.Phone.Contains(filter) ||
				nameof(c.Type).Contains(filter);
			
			var offset = (page - 1) * limit;

			var clients = await _context.Clients
				.Where(bruteFilter)
				.Skip(offset)
				.Take(limit)
				.ToListAsync();

			var totalClients = await _context.Clients.CountAsync();
			var totalPages = (int)Math.Ceiling((double)totalClients / limit);

			return new FindClientsDTO
			{
				Clients = clients,
				TotalClients = totalClients,
				TotalPages = totalPages,
				Page = page
			};
		}

		public async Task InsertAsync(ClientEntity entity)
		{
			var hasOnDb = await _context.Clients.FirstOrDefaultAsync(c => c.Email == entity.Email);

			if (hasOnDb != null)
				throw new ConflictException("Client already exists.");

			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(ClientEntity entity)
		{
			var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == entity.Id);

			if (client == null)
				throw new NotFoundException("Client not exists.");

			client.Name = entity.Name;
			client.Email = entity.Email;
			client.Phone = entity.Phone;
			client.Type = entity.Type;

			await _context.SaveChangesAsync();
		}
	}
}
