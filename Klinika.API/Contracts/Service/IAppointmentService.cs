using Klinika.API.Data.Dto.Appointment;
using Klinika.API.Data.Dto;

namespace Klinika.API.Contracts.Service
{
	public interface IAppointmentService
	{
		Task<IEnumerable<AppointmentReadOnlyDto>> GetAllAppointments();
		Task<AppointmentReadOnlyDto> GetAppointmentById(int appointmentId);
		Task<ResponseDto> CreateAppointment(AppointmentCreateDto appointmentDto);
		Task<ResponseDto> UpdateAppointment(int appointmentId, AppointmentUpdateDto appointmentDto);
		Task<bool> DeleteAppointment(int appointmentId);
	}
}
