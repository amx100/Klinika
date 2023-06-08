using Klinika.API.Data.Dto.Appointment;



namespace Klinika.API.Data.Dto.Diagnose;

public class DiagnoseReadOnlyDto
{
	public int DiagnoseID { get; set; }
	public int AppointmentID { get; set; }
	public AppointmentReadOnlyDto Appointment { get; set; }
}