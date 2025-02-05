using System;
using Microsoft.EntityFrameworkCore;
using Sellix.Context;

namespace Sellix
{
	public static class Startup
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration["MsSql:ConnectionString"] ?? throw new Exception("MsSql:ConnectionString Is Null");

			services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});

			return services;
		}

		public static IApplicationBuilder UseServices(this IApplicationBuilder app)
		{
			return app;
		}
	}
}

