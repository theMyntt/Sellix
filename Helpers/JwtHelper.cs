using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Sellix.Abstractions;
using Sellix.Entities;

namespace Sellix.Helpers
{
	public class JwtHelper : IJwtHelper
	{
		private readonly SigningCredentials _creds;
		private readonly IConfigurationSection _jwt;

		public JwtHelper(IConfiguration configuration)
		{
			var jwtSection = configuration.GetSection("Jwt");
			_jwt = jwtSection;
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["SecretKey"]!));
			_creds = new(key, SecurityAlgorithms.HmacSha256);
		}

		public string GenerateToken(UserEntity user)
		{
			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Role, nameof(user.Role))
			};

			var token = new JwtSecurityToken(
				issuer: _jwt["Issuer"]!,
				audience: _jwt["Audience"]!,
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: _creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}

