using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase

	{
		private readonly IServiceManager _serviceManager;

		public AppointmentController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAppointments()
		{
			var response = await _serviceManager.AppointmentService.GetAllAppointments();
			return Ok(response);
		}

		[HttpGet("{appointmentId}")]
		public async Task<IActionResult> GetAppointmentById(int appointmentId)
		{
			var response = await _serviceManager.AppointmentService.GetAppointmentById(appointmentId);
			if (response is not null)
				return Ok(response);
			return NotFound("Appointment not found.");
		}

		[HttpPost]
		public async Task<IActionResult> CreateAppointment(AppointmentCreateDto appointmentDto)
		{
			var response = await _serviceManager.AppointmentService.CreateAppointment(appointmentDto);

			if (response.IsSuccess)
				return Ok(response);


			return BadRequest(response);
		}

		[HttpPut("{appointmentId}")]
		public async Task<IActionResult> UpdateAppointment(AppointmentUpdateDto appointmentDto, int appointmentId)
		{
			if (!appointmentId.Equals(appointmentDto.AppointmentID))
				return BadRequest("Invalid ID");
			var response = await _serviceManager.AppointmentService.UpdateAppointment(appointmentId, appointmentDto);
			if (response.IsSuccess)
				return Ok(response);

			return BadRequest(response);
		}

		[HttpDelete("{appointmentId}")]
		public async Task<IActionResult> DeleteAppointment(int appointmentId)
		{
			var response = await _serviceManager.AppointmentService.DeleteAppointment(appointmentId);

			if (response)
				return Ok("Appointment Deleted");

			return BadRequest("Failed to Delete Appointment.");
		}
	}
}
