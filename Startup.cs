using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sellix.Abstractions;
using Sellix.Context;
using Sellix.Helpers;
using Sellix.Middlewares;
using Sellix.Repositories;
using Sellix.Services;

namespace Sellix
{
	public static class Startup
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration["MySql:ConnectionString"] ?? throw new Exception("MySql:ConnectionString Is Null");
			var jwtSection = configuration.GetSection("Jwt");
			var key = jwtSection["SecretKey"] ?? throw new Exception("SecretKey Is Null");
			var keyBytes = Encoding.UTF8.GetBytes(key);

			var issuer = jwtSection["Issuer"] ?? throw new Exception("Issuer Is Null");
			var audience = jwtSection["Audience"] ?? throw new Exception("Audience Is Null");

			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = issuer,
						ValidAudience = audience,
						IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
					};
				});
			services.AddAuthorization();

			services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});

			services.AddSingleton<IJwtHelper, JwtHelper>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();

			services.AddScoped<IClientRepository, ClientRepository>();

			return services;
		}

		public static IApplicationBuilder UseServices(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();

			app.UseAuthentication();
			app.UseAuthorization();

			return app;
		}
	}
}

