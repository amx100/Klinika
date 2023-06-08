using Klinika.API.Contracts.Services;

namespace Klinika.API.Contracts.Service
{
	public interface IServiceManager
	{
		IDoctorService DoctorService { get; }
		IAppointmentService AppointmentService { get; }
		IPatientService PatientService { get; }
		IDiagnoseService DiagnoseService { get; }	
		IDepartmentService DepartmentService { get; }
	
	}
}
