using System;
using Microsoft.AspNetCore.Mvc;
using Sellix.Abstractions;
using Sellix.DTOs;

namespace Sellix.Controllers
{
	[ApiController]
	[Route("/api/")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpPost("v1/login")]
		public async Task<IActionResult> LoginAsync(LoginDTO dto)
		{
			var result = await _service.LoginAsync(dto.Email, dto.Password);

			return StatusCode(result.StatusCode, result);
		}

		public async Task<IActionResult> InsertAsync(NewUserDTO dto)
		{

		}
	}
}

