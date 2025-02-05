using System;
using Sellix.Entities;

namespace Sellix.Abstractions
{
	public interface IJwtHelper
	{
		string GenerateToken(UserEntity user);
	}
}

