using System;
using Sellix.Abstractions;
using Sellix.DTOs.Response;

namespace Sellix.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repository;
		private readonly IJwtHelper _jwtHelper;

		public UserService(IUserRepository repository, IJwtHelper jwtHelper)
		{
			_repository = repository;
			_jwtHelper = jwtHelper;
		}

		public async Task<LoginResponseDTO> LoginAsync(string email, string password)
		{
			var user = await _repository.LoginAsync(email, password);
			var token = _jwtHelper.GenerateToken(user);

			return new LoginResponseDTO
			{
				Message = "User found",
				Token = token,
				StatusCode = 200
			};
		}
	}
}

