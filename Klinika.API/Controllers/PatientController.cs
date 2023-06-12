using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
		
		{
		private readonly IServiceManager _serviceManager;

		public PatientController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetPatients()
		{
			var response = await _serviceManager.PatientService.GetAllPatients();
			return Ok(response);
		}

		[HttpGet("{patientId}")]
		public async Task<IActionResult> GetPatientById(int patientId)
		{
			var response = await _serviceManager.PatientService.GetPatientById(patientId);
			if (response is not null)
				return Ok(response);
			return NotFound("Patient not found.");
		}

		[HttpPost]
		public async Task<IActionResult> CreatePatient(PatientCreateDto patientDto)
		{
			var response = await _serviceManager.PatientService.CreatePatient(patientDto);

			if (response.IsSuccess)
				return Ok(response);


			return BadRequest(response);
		}

		[HttpPut("{patientId}")]
		public async Task<IActionResult> UpdatePatient(PatientUpdateDto patientDto, int patientId)
		{
			if (!patientId.Equals(patientDto.patientID))
				return BadRequest("Invalid ID");
			var response = await _serviceManager.PatientService.UpdatePatient(patientId, patientDto);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		[HttpDelete("{patientId}")]
		public async Task<IActionResult> DeletePatient(int patientId)
		{
			var response = await _serviceManager.PatientService.DeletePatient(patientId);

			if (response)
				return Ok("Patient Deleted");

			return BadRequest("Failed to Delete Patient.");
		}
	}
}

