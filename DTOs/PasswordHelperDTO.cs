using System;
namespace Sellix.DTOs
{
	public class PasswordHelperDTO
	{
		public required string Hash { get; set; }
		public required string Salt { get; set; }

		public PasswordHelperDTO()
		{
		}
	}
}

