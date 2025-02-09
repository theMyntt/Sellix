using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sellix.Abstractions;
using Sellix.Context;
using Sellix.DTOs.Response;
using Sellix.Entities;
using Sellix.Exceptions;

namespace Sellix.Repositories
{
	public class SaleRepository : ISaleRepository
	{
		private readonly DatabaseContext _context;

		public SaleRepository(DatabaseContext context)
		{
			_context = context;
		}

		public async Task DeleteAsync(Guid id)
		{
			var sale = await _context.Sales.FindAsync(id);

			if (sale == null)
				throw new NotFoundException("No sale found.");

			_context.Sales.Remove(sale);

			await _context.SaveChangesAsync();
		}

		public async Task<FindSalesDTO> FindAsync(int page, int limit)
		{
			var offset = (page - 1) * limit;

			var sales = await _context.Sales
				.Skip(offset)
				.Take(limit)
				.ToListAsync();

			var totalClients = await _context.Sales.CountAsync();
			var totalPages = (int)Math.Ceiling((double)totalClients / limit);

			return new FindSalesDTO
			{
				Sales = sales,
				TotalClients = totalClients,
				TotalPages = totalPages,
				Page = page
			};
		}

		public async Task<FindSalesDTO> FindAsync(string filter, int page, int limit)
		{
			Expression<Func<SaleEntity, bool>> bruteFilter = s =>
				s.ClientId.ToString() == filter ||
				s.UserId.ToString() == filter ||
				s.User.Name.ToLower().Contains(filter.ToLower()) ||
				s.Client.Name.ToLower().Contains(filter.ToLower()) ||
				s.Product.ToLower().Contains(filter.ToLower()) ||
				s.SaleStatus.ToString() == filter.ToLower(); 

			var offset = (page - 1) * limit;

			var sales = await _context.Sales
				.Where(bruteFilter)
				.Skip(offset)
				.Take(limit)
				.ToListAsync();

			var totalClients = await _context.Sales.CountAsync();
			var totalPages = (int)Math.Ceiling((double)totalClients / limit);

			return new FindSalesDTO
			{
				Sales = sales,
				TotalClients = totalClients,
				TotalPages = totalPages,
				Page = page
			};
		}

		public async Task InsertAsync(SaleEntity sale)
		{
			await _context.Sales.AddAsync(sale);
			await _context.SaveChangesAsync();
		}
	}
}

