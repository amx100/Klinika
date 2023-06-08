using Klinika.API.Data.Dto.Appointment;



namespace Klinika.API.Data.Dto.Diagnose;

public class DiagnoseReadOnlyDto
{
	public int diagnoseID { get; set; }
	public int appointmentID { get; set; }
	public AppointmentReadOnlyDto Appointment { get; set; }
}