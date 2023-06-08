using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Data.Dto.Appointment
{
	public class AppointmentUpdateDto
	{
		public int AppointmentID { get; set; }
		public DateTime appointed_time { get; set; }
		public int PatientID { get; set; }
		public int DoctorID { get; set; }
	}
}
