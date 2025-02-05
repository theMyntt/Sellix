using System;
namespace Sellix.Exceptions
{
	public class GlobalHttpException : Exception
	{
		public int StatusCode { get; private set; }

		public GlobalHttpException(string message, int statusCode) : base(message)
		{
			StatusCode = statusCode;
		}
	}
}

