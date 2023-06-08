using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public DoctorsController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetDoctors()
		{
			var response = await _serviceManager.DoctorService.GetAllDoctors();
			return Ok(response);
		}

		[HttpGet("{doctorId}")]
		public async Task<IActionResult> GetDoctorById(int doctorId)
		{
			var response = await _serviceManager.DoctorService.GetDoctorById(doctorId);
			if (response is not null)
				return Ok(response);
			return NotFound("Doctor not found.");
		}

		[HttpPost]
		public async Task<IActionResult> CreateDoctor(DoctorCreateDto doctorDto)
		{
			var response = await _serviceManager.DoctorService.CreateDoctor(doctorDto);

			if (response.IsSuccess)
				return Ok(response);


			return BadRequest(response);
		}

		[HttpPut("{doctorId}")]
		public async Task<IActionResult> UpdateDoctor(DoctorUpdateDto doctorDto, int doctorId)
		{
			if (!doctorId.Equals(doctorDto.doctorID))
				return BadRequest("Invalid ID");
			var response = await _serviceManager.DoctorService.UpdateDoctor(doctorId, doctorDto);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		[HttpDelete("{doctorId}")]
		public async Task<IActionResult> DeleteDoctor(int doctorId)
		{
			var response = await _serviceManager.DoctorService.DeleteDoctor(doctorId);

			if (response)
				return Ok("Doctor Deleted");

			return BadRequest("Failed to Delete Doctor.");
		}
	}
}
