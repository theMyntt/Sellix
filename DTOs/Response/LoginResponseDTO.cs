using System;
namespace Sellix.DTOs.Response
{
	public class LoginResponseDTO
	{
		public string Message { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
		public int StatusCode { get; set; }

		public LoginResponseDTO()
		{
		}
	}
}

