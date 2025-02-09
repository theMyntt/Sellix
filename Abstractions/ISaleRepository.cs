using System;
using Sellix.DTOs.Response;
using Sellix.Entities;

namespace Sellix.Abstractions
{
	public interface ISaleRepository
	{
		Task InsertAsync(SaleEntity sale);
		Task DeleteAsync(Guid id);
		Task<FindSalesDTO> FindAsync(int page, int limit);
		Task<FindSalesDTO> FindAsync(string filter, int page, int limit);
	}
}

