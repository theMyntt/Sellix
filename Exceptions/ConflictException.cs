using System;
namespace Sellix.Exceptions
{
	public class ConflictException : GlobalHttpException
	{
		public ConflictException(string message) : base(message, 409) 
		{
		}
	}
}

