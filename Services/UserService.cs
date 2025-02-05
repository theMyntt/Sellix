using System;
using System.Text.RegularExpressions;
using Sellix.Abstractions;
using Sellix.DTOs;
using Sellix.DTOs.Response;
using Sellix.Entities;
using Sellix.Entities.Enums;
using Sellix.Helpers;

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

		public async Task<StandardResponse> InsertAsync(NewUserDTO dto)
		{
			var name = Regex.Replace(dto.Name, @"\s+", " ");
			var password = PasswordHelper.Encrypt(dto.Password);

			var user = new UserEntity
			{
				Id = Guid.NewGuid(),
				Name = name.Trim(),
				Email = dto.Email.ToLower().Trim(),
				PasswordHash = password.Hash,
				PasswordSalt = password.Salt,
				IsBlocked = true,
				Role = UserRole.User
			};

			await _repository.InsertAsync(user);

			return new StandardResponse
			{
				Message = "User waiting approval but created.",
				StatusCode = 201
			};
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

