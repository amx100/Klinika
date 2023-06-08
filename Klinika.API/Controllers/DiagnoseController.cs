using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Diagnose;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiagnoseController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public DiagnoseController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetDiagnoses()
		{
			var response = await _serviceManager.DiagnoseService.GetAllDiagnoses();
			return Ok(response);
		}

		[HttpGet("{diagnoseId}")]
		public async Task<IActionResult> GetDiagnoseById(int diagnoseId)
		{
			var response = await _serviceManager.DiagnoseService.GetDiagnoseById(diagnoseId);
			if (response is not null)
				return Ok(response);
			return NotFound("Diagnose not found.");
		}

		[HttpPost]
		public async Task<IActionResult> CreateDiagnose(DiagnoseCreateDto diagnoseDto)
		{
			var response = await _serviceManager.DiagnoseService.CreateDiagnose(diagnoseDto);

			if (response.IsSuccess)
				return Ok(response);


			return BadRequest(response);
		}

		[HttpPut("{diagnoseId}")]
		public async Task<IActionResult> UpdateDiagnose(DiagnoseUpdateDto diagnoseDto, int diagnoseId)
		{
			if (!diagnoseId.Equals(diagnoseDto.diagnoseID))
				return BadRequest("Invalid ID");
			var response = await _serviceManager.DiagnoseService.UpdateDiagnose(diagnoseId, diagnoseDto);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		[HttpDelete("{diagnoseId}")]
		public async Task<IActionResult> DeleteDiagnose(int diagnoseId)
		{
			var response = await _serviceManager.DiagnoseService.DeleteDiagnose(diagnoseId);

			if (response)
				return Ok("Diagnose Deleted");

			return BadRequest("Failed to Delete Diagnose.");
		}
	}
}
