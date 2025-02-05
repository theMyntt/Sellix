using System;
namespace Sellix.DTOs
{
	public class StandardResponse
	{
		public required string Message { get; set; }
		public required int StatusCode { get; set; }

		public StandardResponse()
		{
		}
	}
}

