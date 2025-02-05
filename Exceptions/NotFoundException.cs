using System;
namespace Sellix.Exceptions
{
	public class NotFoundException : GlobalHttpException
	{
		public NotFoundException(string message) : base(message, 404)
		{
		}
	}
}

