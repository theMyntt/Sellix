using System;
using System.Text.Json;
using Sellix.DTOs;
using Sellix.Exceptions;

namespace Sellix.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (GlobalHttpException ex)
			{
				await HandleExceptionAsync(context, ex);	
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, GlobalHttpException ex)
		{
			var response = context.Response;

			response.ContentType = "application/json";
			response.StatusCode = ex.StatusCode;

			var json = new StandardResponse
			{
				Message = ex.Message,
				StatusCode = ex.StatusCode
			};

			return response.WriteAsync(JsonSerializer.Serialize(json));
		}
	}
}

