using System;
using Sellix.Entities;

namespace Sellix.DTOs.Response
{
	public class FindSalesDTO
	{
		public IEnumerable<SaleEntity> Sales { get; set; } = new List<SaleEntity>();
		public int TotalPages { get; set; }
		public int TotalClients { get; set; }
		public int Page { get; set; }
	}
}

