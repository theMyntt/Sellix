using System;
using Microsoft.EntityFrameworkCore;
using Sellix.Abstractions;
using Sellix.Context;
using Sellix.DTOs;
using Sellix.Entities;
using Sellix.Exceptions;
using Sellix.Helpers;

namespace Sellix.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _context;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
		}

		public async Task InsertAsync(UserEntity entity)
		{
			var userExists = await _context.Users
				.FirstOrDefaultAsync(u => u.Email == entity.Email);

			if (userExists != null)
				throw new ConflictException("User already exists");

			await _context.Users.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<UserEntity> LoginAsync(string email, string password)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u =>
				u.Email == email.Trim().ToLower());

			if (user == null)
				throw new NotFoundException("Email/Password incorrect.");

			var isSamePassword = PasswordHelper.AssertEqual(password, new PasswordHelperDTO
			{
				Hash = user.PasswordHash,
				Salt = user.PasswordSalt
			});

			if (!isSamePassword)
				throw new NotFoundException("Email/Password incorrect.");

			if (user.IsBlocked)
				throw new ForbiddenException("Your user is blocked.");

			user.PasswordHash = string.Empty;
			user.PasswordSalt = string.Empty;

			return user;
		}
	}
}

