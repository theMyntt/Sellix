using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sellix.Abstractions;
using Sellix.DTOs;
using Sellix.Entities.Enums;

namespace Sellix.Controllers
{
	[ApiController]
	[Route("/api/")]
	[Tags("Clients")]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _service;

		public ClientController(IClientService service)
		{
			_service = service;
		}

		[HttpPost("v1/client")]
		[Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Admin)}")]
		public async Task<IActionResult> InsertAsync(ClientDTO client)
		{
			var result = await _service.InsertAsync(client);

			return StatusCode(result.StatusCode, result);
		}

		[HttpPut("v1/client/{id:guid}")]
		[Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Admin)}")]
		public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ClientDTO client)
		{
			var result = await _service.UpdateAsync(client, id);

			return StatusCode(result.StatusCode, result);
		}

		[HttpDelete("v1/client/{id:guid}")]
		[Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Admin)}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var result = await _service.DeleteAsync(id);

			return StatusCode(result.StatusCode, result);
		}

		[HttpGet("v1/client")]
		[Authorize]
		public async Task<IActionResult> FindAsync(int page, int limit)
		{
			var result = await _service.FindAsync(page, limit);

			return StatusCode(200, result);
		}

		[HttpGet("v1/client")]
		[Authorize]
		public async Task<IActionResult> FindAsync(string q, int page, int limit)
		{
			var result = await _service.FindAsync(q, page, limit);

			return StatusCode(200, result);
		}
	}
}
