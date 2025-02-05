using System;
using Sellix.DTOs.Response;

namespace Sellix.Abstractions
{
	public interface IUserService
	{
		Task<LoginResponseDTO> LoginAsync(string email, string password);
	}
}

