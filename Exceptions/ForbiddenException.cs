using System;
namespace Sellix.Exceptions
{
	public class ForbiddenException : GlobalHttpException
	{
		public ForbiddenException(string message) : base(message, 403)
		{
		}
	}
}

