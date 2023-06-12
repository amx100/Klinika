using Klinika.API.Data.Dto.Appointment;
using Klinika.API.Data.Dto.Patient;

namespace Klinika.API.Data.Dto.Diagnose;

public class DiagnoseReadOnlyDto
{
	public int diagnoseID { get; set; }
	public PatientReadOnlyDto Patient { get; set; }
	public string name { get; set; }
	public string description { get; set; }
}