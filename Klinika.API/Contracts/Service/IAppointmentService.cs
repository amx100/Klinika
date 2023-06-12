using Klinika.API.Data.Dto.Appointment;
using Klinika.API.Data.Dto;
using Klinika.API.Data.Dto.Patient;

namespace Klinika.API.Contracts.Service
{
	public interface IAppointmentService
	{
		Task<IEnumerable<PatientReadOnlyDto>> GetPatientsByDoctorId(int doctorId);
		Task<IEnumerable<AppointmentReadOnlyDto>> GetAllAppointments();
		Task<AppointmentReadOnlyDto> GetAppointmentById(int appointmentId);
		
		Task<ResponseDto> CreateAppointment(AppointmentCreateDto appointmentDto);
		Task<ResponseDto> UpdateAppointment(int appointmentId, AppointmentUpdateDto appointmentDto);
		Task<bool> DeleteAppointment(int appointmentId);
	}
}
