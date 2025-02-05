using System;
using System.ComponentModel.DataAnnotations;

namespace Sellix.DTOs
{
	public class LoginDTO
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[StringLength(12, MinimumLength = 6)]
		public string Password { get; set; } = string.Empty;

		public LoginDTO()
		{
		}
	}
}

