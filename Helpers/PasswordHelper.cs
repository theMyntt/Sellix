using System;
using System.Security.Cryptography;
using System.Text;
using Sellix.DTOs;

namespace Sellix.Helpers
{
	public class PasswordHelper
	{
		public static PasswordHelperDTO Encrypt(string password)
		{
			using var hmac = new HMACSHA256();

			return new PasswordHelperDTO
			{
				Salt = Convert.ToBase64String(hmac.Key),
				Hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)))
			};
		}

		public static bool AssertEqual(string password, PasswordHelperDTO dto)
		{
			using var hmac = new HMACSHA256(Convert.FromBase64String(dto.Salt));

			var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

			return computedHash == dto.Hash;
		}
	}
}

