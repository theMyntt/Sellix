using System;
using Sellix.Entities;

namespace Sellix.Abstractions
{
	public interface IUserRepository
	{
		Task<UserEntity> LoginAsync(string email, string password);
		Task InsertAsync(UserEntity entity);
	}
}

