using System;
using Sellix.DTOs;
using Sellix.DTOs.Response;

namespace Sellix.Abstractions
{
	public interface IUserService
	{
		Task<LoginResponseDTO> LoginAsync(string email, string password);
		Task<StandardResponse> InsertAsync(NewUserDTO dto);
	}
}

